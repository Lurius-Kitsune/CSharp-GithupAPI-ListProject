using System.Text.Json;

namespace GithubApiDLL.Tools
{
    class JsonDataManager
    {
        /// <summary>
        /// JSON file path where the data is stored.
        /// </summary>
        readonly string jsonFilePath;

        #region Attributs

        /// <summary>
        /// Represents whether the JSON file exists. <br></br>
        /// Return <see langword="true"/> if the file exists, otherwise <see langword="false"/>.
        /// </summary>
        public bool IsFileExists
        {
            get { return File.Exists(jsonFilePath); }
        }
        #endregion
        //=================================================================
        public JsonDataManager(string _filePath, bool _autoCreateFile = false)
        {
            jsonFilePath = _filePath;
            if (_autoCreateFile) CreateFile();
        }

        private void CreateFile()
        {
            if (!IsFileExists)
            {
                // Créer un fichier JSON vide
                File.WriteAllText(jsonFilePath, "{}");
            }
        }

        private string ReadFile()
        {
            if (!IsFileExists) return string.Empty;
            // Lire le contenu du fichier JSON
            string _jsonContent = File.ReadAllText(jsonFilePath);
            return _jsonContent;
        }

        /// <summary>
        /// Read the JSON file and deserialize it into an object of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to which the JSON data should be deserialized.</typeparam>
        /// <returns>Returns an object of <typeparamref name="T"/> if the file exists and contains valid JSON data, otherwise returns <see langword="null"/>.</returns>
        public T? GetDataAs<T>()
        {
            if (!IsFileExists) return default;
            string _jsonContent = ReadFile();
            // Désérialiser le JSON en un objet de type T
            T? _data = JsonSerializer.Deserialize<T>(_jsonContent);
            return _data;
        }

        public Dictionary<string, string>? GetDataAsDictionary()
        {
            if (!IsFileExists) return null;
            string _jsonContent = ReadFile();
            // Désérialiser le JSON en un dictionnaire
            Dictionary<string, string>? _data = JsonSerializer.Deserialize<Dictionary<string, string>>(_jsonContent);
            return _data;
        }

        public bool WriteData<T>(T _data)
        {
            if (!IsFileExists) CreateFile();
            try
            {
                // Sérialiser l'objet en JSON
                string _jsonContent = JsonSerializer.Serialize(_data);
                // Écrire le contenu JSON dans le fichier
                File.WriteAllText(jsonFilePath, _jsonContent);
            }
            catch
            {
                // Si une erreur se produit lors de la sérialisation ou de l'écriture, retourner false
                return false;
            }
            return true;
        }
    }
}
