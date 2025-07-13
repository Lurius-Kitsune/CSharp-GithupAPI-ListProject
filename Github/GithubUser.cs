using ProjectList.Singleton;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectList.Github
{
    public class GithubUser
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
        Vector<Repository>? repositories = new Vector<Repository>();

        [JsonIgnore]
        public Vector<Repository>? Repositories { get => repositories; private set => repositories = value; }

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

        public async Task<Vector<Repository>?> FetchRepositoriesAsync(string token)
        {
            if (string.IsNullOrEmpty(UserUrl))
                return new Vector<Repository>();

            using HttpClient _client = new HttpClient();

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GithubApi.Instance.AccessToken);
            _client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            _client.DefaultRequestHeaders.Add("User-Agent", "ProjectListApp");

            HttpResponseMessage _response = await _client.GetAsync($"{UserUrl}/repos");
            if (!_response.IsSuccessStatusCode)
                return new Vector<Repository>();

            string _content = await _response.Content.ReadAsStringAsync();

            Vector<Repository>? _repositories = JsonSerializer.Deserialize<Vector<Repository>>(_content);

            if (_repositories != null)
            {
                Repositories = _repositories;
            }

            return Repositories;
        }

    }
}
