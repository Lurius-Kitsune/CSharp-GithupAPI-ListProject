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
        static void Main()
        {
            //new FolderBrowserDialog().ShowDialog();
            try
            {
                ApplicationConfiguration.Initialize();
                GithubApi _githubApi = GithubApi.Instance;
                _githubApi.MyApp = new AppMainForm(_githubApi);
                new AppMainForm(_githubApi);
                Task.Run(async () =>
                {
                    await _githubApi.InitAsync();
                });
                Application.Run(_githubApi.MyApp);

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
