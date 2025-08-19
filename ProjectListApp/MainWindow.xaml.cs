using System.Text;
using System.Windows;
using GithubApiDLL;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectListApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            Init();
            InitializeComponent();
            ToogleProjectListTab(GithubApi.Instance.UserInfo.IsTokenPresent);
        }

        private void Init()
        {
            GithubApi _githubApi = GithubApi.Instance;
            _githubApi.OnUserDisconnect += (_sender, _e) =>
            {
                Dispatcher.Invoke(() =>
                {
                    ToogleProjectListTab(false);
                });
            };

            _githubApi.OnUserInfoReady += (_sender, _e) =>
            {
                Dispatcher.Invoke(() =>
                {
                    ToogleProjectListTab(true);
                });
            };

            

        }

        private void ToogleProjectListTab(bool _isVisible)
        {
            ProjectListTab.IsEnabled = _isVisible;
        }
    }
}