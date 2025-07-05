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
    }
}
