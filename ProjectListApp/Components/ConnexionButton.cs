using GithubApiDLL;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ProjectListApp.Components
{
    partial class ConnexionButton : Button
    {
        bool isConnected;

        public ConnexionButton()
        {
            this.Click += OnClick;
            UpdateButtonStyle();

            GithubApi.Instance.OnUserInfoReady += (_sender, _user) =>
            {
                isConnected = _user.IsTokenPresent;
                Dispatcher.Invoke(() =>
                {
                    UpdateButtonStyle();
                });
            };

            GithubApi.Instance.OnUserDisconnect += (_sender, _e) =>
            {
                isConnected = false;
                Dispatcher.Invoke(() =>
                {
                    UpdateButtonStyle();
                });
            };
        }

        private void OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            GithubApi _githubApi = GithubApi.Instance;
            try
            {
                if(!isConnected)
                {
                    _githubApi.InitOAuthConnexion();
                }
                else
                {
                    _githubApi.DisconnectUser();
                }
            }
            catch (Exception _ex)
            {
                Dispatcher.Invoke(() =>
                {
                    MessageBox.Show($"An error occurred while trying to connect: {_ex.Message}", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
                });
            }
        }

        private void UpdateButtonStyle()
        {
            isConnected = GithubApi.Instance.UserInfo.IsTokenPresent;
            this.Background = isConnected ? ConnectedStyle.Background : DisconnectedStyle.Background;
            this.Foreground = isConnected ? ConnectedStyle.Foreground : DisconnectedStyle.Foreground;
            this.BorderBrush = isConnected ? ConnectedStyle.BorderBrush : DisconnectedStyle.BorderBrush;
            this.OpacityMask = isConnected ? ConnectedStyle.OpacityMask : DisconnectedStyle.OpacityMask;
            this.Content = isConnected ? ConnectedText : DisconnectedText;
        }
    }
}
