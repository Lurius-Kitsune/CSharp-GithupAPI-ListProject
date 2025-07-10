using ProjectList.Github;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;

namespace ProjectList.Singleton
{
    public class GithubApi
    {
        string accessToken;
        string clientId; // Replace with your actual client ID  
        string clientSecret;

        volatile GithubUser userInfo;

        public event EventHandler<string> OnTokenReceived;
        public event EventHandler<GithubUser> OnUserInfoReady;
        public event EventHandler OnUserDisconnect;

        static GithubApi? instance;


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
        public string AccessToken { get => string.IsNullOrEmpty(accessToken) ? "Aucun accessToken" : accessToken; private set => accessToken = value; }
        public bool IsAccessTokenPresent()
        {
            return !string.IsNullOrEmpty(AccessToken);
        }
        public GithubUser UserInfo { get => userInfo; private set => userInfo = value; }
        #endregion

        private GithubApi()
        {
            // Default init delegate
            OnUserInfoReady = (_sender, _user) => { };
            OnUserDisconnect = (_sender, _e) => { };
            accessToken = DataManager.Instance.GetApiAccessTokenFromData();
            clientId = Environment.GetEnvironmentVariable("CLIENT_ID")!;
            clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET")!;
            userInfo = new GithubUser();
            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
                throw new InvalidOperationException("GitHub client ID or secret is not set. Please set the environment variables CLIENT_ID and CLIENT_SECRET.");

            if (!string.IsNullOrEmpty(AccessToken))
            {
                OnTokenReceived?.Invoke(this, AccessToken);
            }

            OnTokenReceived += (_sender, _token) =>
            {
                AccessToken = _token;
                DataManager.                Instance.UpdateGithubApiAccessToken(AccessToken);
            };

        }

        public async Task InitAsync()
        {
            await CatchUserInfo();
        }

        private async Task CatchUserInfo()
        {
            if (string.IsNullOrEmpty(AccessToken)) return;

            using HttpClient _client = new HttpClient();

            // add value to header
            _client.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);
            _client.DefaultRequestHeaders.Add("User-Agent", "ProjectListApp"); // GitHub API requires a User-Agent header

            HttpResponseMessage _response = await _client.GetAsync("https://api.github.com/user");
            string _responseString = await _response.Content.ReadAsStringAsync();

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
            // Lancer l’écoute sans bloquer
            using Task _ = Task.Run(OpenListenerHTTP);

            // Ensuite, ouvrir l'URL GitHub
            InitializeTokenGit();
        }

        private void InitializeTokenGit()
        {
            try
            {
                // Oauth URL for GitHub accessToken generation
                string _authUrl = "https://github.com/login/oauth/authorize?client_id="+clientId+"&scope=repo,user&redirect_uri=http://localhost:8080/callback";

                // Start the process to open the URL
                if (!Uri.IsWellFormedUriString(_authUrl, UriKind.Absolute))
                {
                    throw new UriFormatException("The provided URL is not a valid absolute URI.");
                }

                // Attempt to start the process to open the URL
                ProcessStartInfo _startInfo = new ProcessStartInfo
                {
                    FileName = _authUrl,
                    UseShellExecute = true // Use the default browser to open the URL
                };
                Process.Start(_startInfo);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Can't catch token: {ex.Message}", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void OpenListenerHTTP()
        {
            HttpListener _listener = new HttpListener();
            _listener.Prefixes.Add("http://localhost:8080/callback/");
            _listener.Start();
            HttpListenerContext _context = await _listener.GetContextAsync();
            HttpListenerRequest _request = _context.Request;
            HttpListenerResponse _response = _context.Response;

            string? _code = _request.QueryString["code"];
            if (_code == null) throw new InvalidOperationException("Authorization code is missing in the request.");


            string responseString = "<html><body>Authorization accessToken received. You may close this window.</body></html>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            _response.ContentLength64 = buffer.Length;
            await _response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            _response.OutputStream.Close();

            _listener.Stop();
            if (string.IsNullOrEmpty(_code))
            {
                throw new InvalidOperationException("Authorization accessToken is missing in the request.");
            }
            OnTokenReceived.Invoke(this, await ExchangeCodeForToken(_code));
            await CatchUserInfo();
        }

        private async Task<string> ExchangeCodeForToken(string _code)
        {
            using (HttpClient client = new HttpClient())
            {
                Dictionary<string, string> _values = new Dictionary<string, string>
                {
                    { "client_id", clientId },
                    { "client_secret", clientSecret }, // Ne pas commit ceci !!
                    { "code", _code },
                    { "redirect_uri", "http://localhost:8080/callback" }
                };

                FormUrlEncodedContent _content = new FormUrlEncodedContent(_values);
                HttpResponseMessage _response = await client.PostAsync("https://github.com/login/oauth/access_token", _content);
                string _responseString = await _response.Content.ReadAsStringAsync();

                NameValueCollection? _queryParams = HttpUtility.ParseQueryString(_responseString);

                string _accessToken = _queryParams["access_token"]!;

                Console.WriteLine("Access accessToken : " + _accessToken);
                return _accessToken;
            }
        }

        public void DisconnectUser()
        {
            RevokeToken();
        }

        private async void RevokeToken()
        {

            using (HttpClient _client = new HttpClient())
            {
                // Corps de la requête
                object _data = new
                {
                    access_token = AccessToken
                };
                string _json = JsonSerializer.Serialize(_data);

                string _base64Credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
                // Set the Authorization header with Basic authentication
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _base64Credentials);
                _client.DefaultRequestHeaders.Add("User-Agent", "ProjectListApp");

                StringContent _content = new StringContent(_json, Encoding.UTF8, "application/json");
                HttpResponseMessage _response = await _client.PostAsync($"https://api.github.com/applications/{clientId}/token", _content);

                if (_response.IsSuccessStatusCode)
                {
                    AccessToken = string.Empty;
                    userInfo = new GithubUser();
                    DataManager.Instance.UpdateGithubApiAccessToken(AccessToken);
                    OnUserDisconnect?.Invoke(this, EventArgs.Empty);

                    MessageBox.Show(
                        "Token successfully revoked. You have been disconnected.",
                        "Token Revoked",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    string _error = await _response.Content.ReadAsStringAsync();
                    MessageBox.Show(
                        "Erreur lors de la révocation du token. Veuillez réessayer. \n Code : " + _error,
                        "Erreur de révocation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
