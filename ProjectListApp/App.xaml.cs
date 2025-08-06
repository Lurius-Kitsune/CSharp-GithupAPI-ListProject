using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using GithubApiDLL;

namespace ProjectListApp
{
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            try
            {
                App _app = new App();
                InitApp().GetAwaiter().GetResult();
                MainWindow _mainWindow = new MainWindow();
                _app.Run(_mainWindow);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

                string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error_log.txt");
                File.AppendAllText(logPath, $"[{DateTime.Now}] {ex.Message}\n{ex.StackTrace}\n");
            }
        }

        private static async Task InitApp()
        {
            GithubApi _githubApi = GithubApi.Instance;
            await _githubApi.InitAsync();
        }
    }
}
