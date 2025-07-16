using ProjectList.Github;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ProjectList.Singleton
{
    class GithubApi
    {
        public event EventHandler<string> OnTokenReceived;
        public event EventHandler<string> OnDeviceCodeReceived;
        public event EventHandler<GithubUser> OnUserInfoReady;
        public event EventHandler OnUserDisconnect;

        private static GithubApi? instance;
        private HttpClient client = new HttpClient();
        private AppMainForm myApp;

        private string accessToken;
        private string clientId;
        private volatile GithubUser userInfo;

        #region Attribute
        public static GithubApi Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GithubApi();
                }
                return instance;
            }
        }
        public string AccessToken { get => string.IsNullOrEmpty(accessToken) ? "Aucun _accessToken" : accessToken; private set => accessToken = value; }
        public bool IsAccessTokenPresent()
        {
            return !string.IsNullOrEmpty(AccessToken);
        }
        public GithubUser UserInfo { get => userInfo; private set => userInfo = value; }
        public AppMainForm MyApp { get => myApp; set => myApp = value; }
        #endregion

        private GithubApi()
        {
            // Default init delegate
            OnUserInfoReady = (_sender, _user) => { };
            OnUserDisconnect = (_sender, _e) => { };
            OnDeviceCodeReceived = (_sender, _deviceCode) => { };
            OnTokenReceived += (_sender, _token) =>
            {
                AccessToken = _token;
                DataManager.Instance.UpdateGithubApiAccessToken(AccessToken);
            };
            accessToken = DataManager.Instance.GetApiAccessTokenFromData();
            clientId = "Iv23li0agB78XVas0WCW";
            userInfo = new GithubUser();
            if (string.IsNullOrEmpty(clientId))
                throw new InvalidOperationException("GitHub client ID or secret is not set. Please set the environment variables CLIENT_ID and CLIENT_SECRET.");

            if (IsAccessTokenPresent())
                OnTokenReceived?.Invoke(this, AccessToken);

            client.BaseAddress = new Uri("https://github.com/");

        }

        public async Task InitAsync()
        {
            await CatchUserInfo();
        }

        private async Task CatchUserInfo()
        {
            if (string.IsNullOrEmpty(AccessToken)) return;

            // add value to header
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);
            client.DefaultRequestHeaders.Add("User-Agent", "ProjectListApp"); // GitHub API requires a User-Agent header

            HttpResponseMessage _response = await client.GetAsync("https://api.github.com/user");
            string _responseString = await _response.Content.ReadAsStringAsync();
            if (!_response.IsSuccessStatusCode)
            {
                DisconnectUser();
                return;
            }

            // Deserialize the JSON response to a User object
            UserInfo = JsonSerializer.Deserialize<GithubUser>(_responseString)!;
            if (UserInfo != null) await UserInfo.InitAvatarImageAsync();
            OnUserInfoReady.Invoke(this, UserInfo!);
        }

        #region OAuth
        /// <summary>
        /// Initializes the OAuth connection to GitHub to retrieve the access token.
        /// </summary>
        /// <returns>True if no timeout</returns>
        public void InitOAuthConnexion()
        {
            // lancer l'apelle dans un autre thread pour ne pas bloquer l'interface utilisateur
            Task.Run(async () =>
            {
                try
                {
                    await InitializeTokenGit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de l'initialisation de la connexion OAuth : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });

        }

        private async Task InitializeTokenGit()
        {
            // Catch device code  using deviceflow
            if (string.IsNullOrEmpty(clientId)) throw new InvalidOperationException("GitHub client ID is not set. Please set the environment variable CLIENT_ID.");

            JsonElement _root = await GetDeviceCodeAsync();

            string _deviceCode = _root.GetProperty("device_code").GetString()!;
            string _userCode = _root.GetProperty("user_code").GetString()!;
            string _verificationUri = _root.GetProperty("verification_uri").GetString()!;
            int _expiresIn = _root.GetProperty("expires_in").GetInt32();
            int _interval = _root.GetProperty("interval").GetInt32();

            // Start the process to open the URL
            if (!Uri.IsWellFormedUriString(_verificationUri, UriKind.Absolute))
                throw new UriFormatException("The provided URL is not a valid absolute URI.");

            OnDeviceCodeReceived?.Invoke(this, _userCode);


            // Attempt to start the process to open the URL
            ProcessStartInfo _startInfo = new ProcessStartInfo
            {
                FileName = _verificationUri,
                UseShellExecute = true // Use the default browser to open the URL
            };
            Process.Start(_startInfo);

            string _accessToken = await CatchAccessToken(_interval, _deviceCode);
            if (!string.IsNullOrEmpty(_accessToken))
            {
                AccessToken = _accessToken;
                OnTokenReceived?.Invoke(this, AccessToken);
                await CatchUserInfo();
            }
            else
            {
                MessageBox.Show("L'authentification a �chou�e. Veuillez réssayer.", "Erreur d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task<JsonElement> GetDeviceCodeAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent _content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("scope", "repo read:user")
                });

            HttpResponseMessage _response = await client.PostAsync("login/device/code", _content);

            if (!_response.IsSuccessStatusCode) throw new HttpRequestException($"Failed to initiate OAuth connection. Status code: {_response.StatusCode}");

            return JsonDocument.Parse(await _response.Content.ReadAsStringAsync()).RootElement;
        }

        private async Task<string> CatchAccessToken(int _interval, string _deviceCode)
        {
            while (!myApp.IsAuthCancelled)
            {
                await Task.Delay(_interval * 1000);
                var _tokenResponse = await client.PostAsync(
                "login/oauth/access_token",
                new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("device_code", _deviceCode),
                    new KeyValuePair<string, string>("grant_type", "urn:ietf:params:oauth:grant-type:device_code")
                }));

                var _tokenContent = JsonDocument.Parse(await _tokenResponse.Content.ReadAsStringAsync()).RootElement;

                if (_tokenContent.TryGetProperty("access_token", out var _accessTokenProp))
                {
                    string _accessToken = _accessTokenProp.GetString()!;
                    Console.WriteLine($"Token reçu : {_accessToken}");
                    if (!string.IsNullOrEmpty(_accessToken))
                    {
                        return _accessToken;
                    }
                    // OK, on peut utiliser le token
                }
                else if (_tokenContent.TryGetProperty("error", out var _errorProp))
                {
                    string? _error = _errorProp.GetString();

                    if (_error == "authorization_pending")
                    {
                        // Continue à attendre
                        continue;
                    }
                    else if (_error == "slow_down")
                    {
                        _interval += 5;
                    }
                    else
                    {
                        MessageBox.Show($"Erreur OAuth : {_error}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return string.Empty;
                    }
                }
            }
            return string.Empty;
        }

        public void DisconnectUser()
        {
            AccessToken = string.Empty;
            userInfo = new GithubUser();
            DataManager.Instance.UpdateGithubApiAccessToken(AccessToken);
            OnUserDisconnect?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
