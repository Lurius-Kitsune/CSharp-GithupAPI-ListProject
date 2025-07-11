using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectList.Singleton
{
    public class DataManager
    {

        static DataManager? instance = null;
        readonly string jsonFilePath = "data.json"; // Chemin du fichier JSON

        public static DataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataManager();
                }
                return instance;
            }
        }


        private DataManager()
        {
            // Initialisation si nécessaire
        }

        public string GetApiAccessTokenFromData()
        {
            if (!IsFileExists()) return string.Empty;

            string _jsonContent = File.ReadAllText(jsonFilePath);
            Dictionary<string, string>? _data = JsonSerializer.Deserialize<Dictionary<string, string>>(_jsonContent);

            if (_data == null || !_data.ContainsKey("githubApiAccessToken"))
                return string.Empty;
            return _data["githubApiAccessToken"];
        }

        private void CreateFile()
        {
            if (!IsFileExists())
            {
                // Créer un fichier JSON vide
                File.WriteAllText(jsonFilePath, "{}");
            }
        }

        public bool IsFileExists()
        {
            return File.Exists(jsonFilePath);
        }

        public void UpdateGithubApiAccessToken(string _token)
        {
            if (!IsFileExists()) CreateFile();
            // Lire le contenu du fichier JSON
            string jsonContent = System.IO.File.ReadAllText(jsonFilePath);
            // Désérialiser le JSON en un dictionnaire
            Dictionary<string, string>? data = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);
            // Mettre à jour le accessToken
            if (data != null)
            {
                data["githubApiAccessToken"] = _token;
                // Sérialiser le dictionnaire en JSON
                string updatedJsonContent = System.Text.Json.JsonSerializer.Serialize(data);
                // Écrire le contenu mis à jour dans le fichier JSON
                System.IO.File.WriteAllText(jsonFilePath, updatedJsonContent);
            }
        }

        public bool IsAccessTokenPresent()
        {
            if (!IsFileExists()) return false;

            string _jsonContent = File.ReadAllText(jsonFilePath);

            Dictionary<string, string>?  _data = JsonSerializer.Deserialize<Dictionary<string, string>>(_jsonContent);

            if (_data == null || 
                !_data.ContainsKey("githubApiAccessToken") || 
                string.IsNullOrEmpty(_data["githubApiAccessToken"]) ||
                _data["githubApiAccessToken"].Substring(0, 3) != "ghu")
                return false;

            return true;
        }
    }
}
