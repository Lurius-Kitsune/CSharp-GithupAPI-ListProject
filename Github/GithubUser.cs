using ProjectList.Singleton;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectList.Github
{
    class GithubUser
    {
        [JsonIgnore]
        private Image? avatarImage;
        [JsonPropertyName("avatar_url")]
        public string? AvatarUrl { get; init; }
        [JsonPropertyName("login")]
        public string? UserName { get; init; }
        [JsonPropertyName("html_url")]
        public string? UserUrl { get; init; }

        [JsonIgnore]
        public int FollowersCount { get; private set; }
        [JsonIgnore]
        public int FollowingCount { get; private set; }
        [JsonIgnore]
        public bool IsPro { get; private set; }

        [JsonIgnore]
        public Image? AvatarImage => avatarImage;

        [JsonIgnore]
        List<Repository>? repositories = new List<Repository>();

        [JsonIgnore]
        public List<Repository>? Repositories { get => repositories; private set => repositories = value; }

        public event EventHandler<List<Repository>> OnRepositoriesFetched;

        public GithubUser()
        {
            avatarImage = null;
            AvatarUrl = string.Empty;
            UserName = string.Empty;
            UserUrl = string.Empty;
            FollowersCount = 0;
            FollowingCount = 0;
            IsPro = false;
        }

        // Pas de constructeur JsonConstructor ici
        // Laisse System.Text.Json utiliser le constructeur par défaut
        // et les setters privés
        public async Task InitAvatarImageAsync()
        {
            if (!string.IsNullOrEmpty(AvatarUrl))
            {
                using var client = new HttpClient();
                using var stream = await client.GetStreamAsync(AvatarUrl);
                avatarImage = Image.FromStream(stream);
            }
        }

        public async Task<List<Repository>?> FetchRepositoriesAsync(RepositoryFilter _filter)
        {
            if (string.IsNullOrEmpty(UserUrl))
                return new List<Repository>();

            using HttpClient _client = new HttpClient();

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GithubApi.Instance.AccessToken);
            _client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            _client.DefaultRequestHeaders.Add("User-Agent", "ProjectListApp");

            HttpResponseMessage _response = await _client.GetAsync("https://api.github.com/user/repos?per_page=100&" + _filter.ToString());
            if (!_response.IsSuccessStatusCode)
                return new List<Repository>();

            string _content = await _response.Content.ReadAsStringAsync();
            List<Repository>? _repositories;
            try
            {
                _repositories = JsonSerializer.Deserialize<List<Repository>>(_content);
            }
            catch (JsonException _e)
            {
                MessageBox.Show($"Error deserializing repositories: {_e.Message}", "Deserialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Handle deserialization error
                return new  List<Repository>();
            }

            List<Repository> _filteredRepository = new List<Repository>();

            foreach (Repository _repo in _repositories)
            {
                if (_filter.IsArchived && !_repo.Archived) continue;
                if (_filter.IsForked && !_repo.Fork) continue;
                _filteredRepository.Add(_repo);

            }

            if (_repositories != null)
            {
                Repositories = _filteredRepository;
                OnRepositoriesFetched?.Invoke(this, Repositories);
            }

            return Repositories;
        }

    }
}
