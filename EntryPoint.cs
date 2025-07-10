using ProjectList.Singleton;
using DotNetEnv;
using System.Diagnostics;
namespace ProjectList
{
    internal static class EntryPoint
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            try
            {
                ApplicationConfiguration.Initialize();
                Env.TraversePath().Load();
                GithubApi _githubApi = GithubApi.Instance;
                await _githubApi.InitAsync();
                Application.Run(new AppMainForm(_githubApi));
            }
            catch (Exception _ex)
            {
                // Handle exceptions, log them or show a message box
                MessageBox.Show($"An error occurred: {_ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Log it in a file with a timestamp
                string _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error_log.txt");
                using (StreamWriter _writer = new StreamWriter(_logFilePath, true))
                {
                    _writer.WriteLine($"[{DateTime.Now}] {_ex.Message}");
                    _writer.WriteLine(_ex.StackTrace);
                }
            }
        }
    }
}
