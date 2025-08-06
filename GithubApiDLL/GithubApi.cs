using GithubApiDLL.Data;
using GithubApiDLL.Tools;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace GithubApiDLL
{
    public class GithubApi
    {
        #region Events
        /// <summary>
        /// Occurs when the access token is received.<br></br>
        /// The event provides a <see cref="string"/> containing the access token.
        /// </summary>
        public event EventHandler<string> OnTokenReceived = delegate { };

        /// <summary>
        /// Occurs when the device code is received during the OAuth process.<br></br>
        /// The event provides a <see cref="string"/> containing the device code.
        /// </summary>
        public event EventHandler<string> OnDeviceCodeReceived = delegate { };

        /// <summary>
        /// Occurs when the user information is ready. <br></br>
        /// The event provides a <see cref="GithubUser"/> object containing the user information.
        /// </summary>
        public event EventHandler<GithubUser> OnUserInfoReady = delegate { };

        /// <summary>
        /// Occurs when the user disconnects from GitHub.
        /// </summary>
        public event EventHandler OnUserDisconnect = delegate { };
        /// <summary>
        /// This event is triggered when the user cancels the authentication process.<br></br>
        /// </summary>
        public event EventHandler OnUserCancelAuth = delegate { };
        #endregion

        static GithubApi? instance;
        HttpClient client = new HttpClient();

        string clientId;
        GithubUser userInfo;
        bool isAuthCancelled;
        JsonDataManager dataManager;

        #region Attribute
        /// <summary>
        /// The singleton instance of the <see cref="GithubApi"/> class.
        /// </summary>
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
        public bool IsAccessTokenPresent
        {
            get { return !string.IsNullOrEmpty(UserInfo.Token); }
        }
        /// <summary>
        /// The <see cref="GithubUser"/> object containing the user information.<br></br>
        /// </summary>
        public GithubUser UserInfo { get => userInfo; private set => userInfo = value; }
        #endregion

        private GithubApi()
        {
            dataManager = new JsonDataManager("data.json", true);
            userInfo = dataManager.GetDataAs<GithubUser>() ?? new GithubUser();
            OnUserCancelAuth = (_sender, _e) => { isAuthCancelled = true; };
            clientId = "Iv23li0agB78XVas0WCW";

            if (string.IsNullOrEmpty(clientId))
                throw new InvalidOperationException("GitHub client ID or secret is not set. Please set the environment variables CLIENT_ID and CLIENT_SECRET.");

            if (IsAccessTokenPresent)
                OnTokenReceived?.Invoke(this, UserInfo.Token!);

            client.BaseAddress = new Uri("https://github.com/");

        }

        public async Task InitAsync()
        {
            if (UserInfo == null || !UserInfo.IsTokenPresent) return;
            try
            {
                await CatchUserInfo(UserInfo.Token!);
            }
            catch (InvalidGithubTokenException)
            {
                DisconnectUser();
            }
        }

        private async Task CatchUserInfo(string _accessToken)
        {
            if (string.IsNullOrEmpty(_accessToken)) return;

            // add value to header
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _accessToken);
            // GitHub API requires a User-Agent header
            client.DefaultRequestHeaders.Add("User-Agent", "ProjectListApp");

            HttpResponseMessage _response = await client.GetAsync("https://api.github.com/user");
            string _responseString = await _response.Content.ReadAsStringAsync();
            if (!_response.IsSuccessStatusCode)
            {
                switch (_response.StatusCode)
                {
                    case System.Net.HttpStatusCode.Unauthorized:
                        throw new InvalidGithubTokenException("The provided GitHub token is invalid or expired.");
                    default:
                        throw new HttpRequestException($"Failed to fetch user info. Status code: {_response.StatusCode}, Response: {_responseString}"); ;
                }
            }
            // Deserialize the JSON response to a User object
            UserInfo = JsonSerializer.Deserialize<GithubUser>(_responseString)!;
            if (UserInfo != null) await UserInfo.InitAvatarImageAsync();
            UserInfo!.Token = _accessToken;
            dataManager.WriteData(UserInfo);
            OnUserInfoReady.Invoke(this, UserInfo!);
        }

        #region OAuth
        /// <summary>
        /// Initializes the OAuth connection to GitHub to retrieve the access token.
        /// </summary>
        /// /// <returns><see cref="bool"/> true if initialization completed before timeout; otherwise, false.</returns>
        public void InitOAuthConnexion()
        {
            // lancer l'apelle dans un autre thread pour ne pas bloquer l'interface utilisateur
            Task.Run(async () =>
            {
                await InitializeTokenGit();
            });

        }

        private async Task InitializeTokenGit()
        {
            // Catch device code  using deviceflow
            if (string.IsNullOrEmpty(clientId))
                throw new InvalidOperationException("GitHub client ID is not set or updated please contact the code Owner.");

            JsonElement _root = await GetDeviceCodeAsync();

            // TODO convert to a class JSON
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
                OnTokenReceived?.Invoke(this, _accessToken);
                await CatchUserInfo(_accessToken);
            }
            else
            {
                // TODO :  DO NOT use MessageBox in a library, use an event instead
                //MessageBox.Show("L'authentification a �chou�e. Veuillez réssayer.", "Erreur d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (!_response.IsSuccessStatusCode)
                throw new HttpRequestException($"Failed to initiate OAuth connection. Status code: {_response.StatusCode}");

            return JsonDocument.Parse(await _response.Content.ReadAsStringAsync()).RootElement;
        }

        private async Task<string> CatchAccessToken(int _interval, string _deviceCode)
        {
            while (!isAuthCancelled)
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

                //Todo converte to a class JSON
                JsonElement _tokenContent = JsonDocument.Parse(await _tokenResponse.Content.ReadAsStringAsync()).RootElement;

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
                        //MessageBox.Show($"Erreur OAuth : {_error}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return string.Empty;
                    }
                }
            }
            isAuthCancelled = false; // Reset the cancellation flag
            return string.Empty;
        }

        /// <summary>
        /// Disconnects the user from GitHub by clearing the access token and user information.<br></br>
        /// </summary>
        public void DisconnectUser()
        {
            userInfo = new GithubUser();
            dataManager.WriteData(userInfo);
            OnUserDisconnect?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
