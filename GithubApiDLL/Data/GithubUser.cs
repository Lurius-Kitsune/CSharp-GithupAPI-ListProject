using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GithubApiDLL.Data
{
    public class GithubUser
    {
        #region Events
        /// <summary>
        /// Occurs when the repositories are fetched. <br></br>
        /// Returns a <see cref="List{T}">List&lt;<see cref="Repository"/>&gt;</see>.
        /// </summary>
        public event EventHandler<List<Repository>> OnRepositoriesFetched;
        #endregion

        [JsonIgnore]
        private Stream? avatarImage;

        [JsonIgnore]
        List<Repository>? repositories = new List<Repository>();

        #region Attributs
        [JsonPropertyName("avatar_url")]
        public string? AvatarUrl { get; init; }
        [JsonPropertyName("login")]
        public string? UserName { get; init; }
        [JsonPropertyName("html_url")]
        public string? UserUrl { get; init; }
        [JsonPropertyName("token")]
        public string? Token { get; set; }

        [JsonIgnore]
        public bool IsTokenPresent { get => !string.IsNullOrEmpty(Token); }

        [JsonIgnore]
        public int FollowersCount { get; private set; }
        [JsonIgnore]
        public int FollowingCount { get; private set; }
        [JsonIgnore]
        public bool IsPro { get; private set; }

        [JsonIgnore]
        public Stream? AvatarImage => avatarImage;

        [JsonIgnore]
        public List<Repository>? Repositories { get => repositories; private set => repositories = value; }
        #endregion

        public GithubUser()
        {
            avatarImage = null;
            AvatarUrl = string.Empty;
            UserName = string.Empty;
            UserUrl = string.Empty;
            Token = string.Empty;
            FollowersCount = 0;
            FollowingCount = 0;
            IsPro = false;
            repositories = new List<Repository>();
            OnRepositoriesFetched = delegate { };
        }

        // Pas de constructeur JsonConstructor ici
        // Laisse System.Text.Json utiliser le constructeur par défaut
        // et les setters privés

        /// <summary>
        /// Initializes the avatar image asynchronously from the AvatarUrl.
        /// </summary>
        public async Task InitAvatarImageAsync()
        {
            if (!string.IsNullOrEmpty(AvatarUrl))
            {
                using HttpClient client = new HttpClient();
                avatarImage = await client.GetStreamAsync(AvatarUrl);
            }
        }

        /// <summary>
        /// Fetches the repositories of the user based on the provided filter.
        /// </summary>
        /// <param name="_filter">The <see cref="RepositoryFilter"/> to filter the repositories.</param>
        /// <returns>Returns a <see cref="List{T}">List&lt;<see cref="Repository"/>&gt;</see>.</returns>
        public async Task<List<Repository>?> FetchRepositoriesAsync(RepositoryFilter _filter)
        {
            Repositories = new List<Repository>();
            if (string.IsNullOrEmpty(UserUrl) || string.IsNullOrEmpty(Token))
                return new List<Repository>();

            using HttpClient _client = new HttpClient();

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            _client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            _client.DefaultRequestHeaders.Add("User-Agent", "ProjectListApp");

            HttpResponseMessage _response = await _client.GetAsync("https://api.github.com/user/repos?per_page=100&" + _filter.ToString());
            if (!_response.IsSuccessStatusCode)
                return new List<Repository>();

            string _content = await _response.Content.ReadAsStringAsync();
            List<Repository>? _repositories;
            try
            {
                _repositories = JsonSerializer.Deserialize<List<Repository>>(_content) ?? new List<Repository>();

                List<Repository> _filteredRepository = new List<Repository>();

                foreach (Repository _repo in _repositories)
                {
                    if (_filter.IsArchived && !_repo.Archived) continue;
                    if (_filter.IsForked && !_repo.Fork) continue;
                    Repositories!.Add(_repo);
                }
                OnRepositoriesFetched?.Invoke(this, Repositories);

                return Repositories;
            }
            catch (JsonException _e)
            {
                //MessageBox.Show($"Error deserializing repositories: {_e.Message}", "Deserialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Handle deserialization error
                return new List<Repository>();
            }
        }

    }
}
