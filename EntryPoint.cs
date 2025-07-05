using ProjectList.Singleton;
using DotNetEnv;
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
            ApplicationConfiguration.Initialize();
            Env.TraversePath().Load();
            GithubApi _githubApi = GithubApi.Instance;
            await _githubApi.InitAsync();
            Application.Run(new Form1(_githubApi));
        }
    }
}
