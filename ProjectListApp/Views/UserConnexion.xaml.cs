using GithubApiDLL;
using GithubApiDLL.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ProjectListApp.Views
{
    /// <summary>
    /// Logique d'interaction pour UserConnexion.xaml
    /// </summary>
    public partial class UserConnexion : UserControl
    {
        private GithubApi githubApi;

        public UserConnexion()
        {
            InitializeComponent();
            githubApi = GithubApi.Instance;
            githubApi.OnDeviceCodeReceived += OnDeviceCodeReceived;
            githubApi.OnUserCancelAuth += OnUserAuthFinished;
            githubApi.OnUserInfoReady += (_sender, _user) =>
            {
                OnUserAuthFinished(_sender, null);
            };

            SetupRainbowAnimation(nameof(gradienColorStop1));
            SetupRainbowAnimation(nameof(gradienColorStop2), 0.5f);
        }

        private void SetupRainbowAnimation(string _name, float _delay = 0f, float _timeSpace = 0.1f)
        {
            Color[] _rainbowColors = new Color[]
            {
                Colors.Red,
                Colors.Orange,
                Colors.Yellow,
                Colors.Green,
                Colors.Blue,
                Colors.Indigo,
                Colors.Violet,
                Colors.Red,
            };

            Storyboard _storyboard = new Storyboard();

            Loaded += (object _sender, RoutedEventArgs _e) =>
            {
                _storyboard.Begin(this);
            };
            _storyboard.RepeatBehavior = RepeatBehavior.Forever;

            ColorAnimationUsingKeyFrames _colorAnimation = new ColorAnimationUsingKeyFrames();
            Storyboard.SetTargetName(_colorAnimation, _name);
            Storyboard.SetTargetProperty(_colorAnimation, new PropertyPath("Color"));
            int _colorLength = _rainbowColors.Length;
            for (int i = 0; i < _colorLength; i++)
            {
                _colorAnimation.KeyFrames.Add(new LinearColorKeyFrame{
                    Value = _rainbowColors[i],
                    KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(_delay + i * _timeSpace))
                });
            }
            
            _storyboard.Children.Add(_colorAnimation);
        }

        private void Button_Click(object? sender, RoutedEventArgs e)
        {
            GithubApi.Instance.InitOAuthConnexion();
        }

        private void OnDeviceCodeReceived(object? _sender, string _deviceCode)
        {
            Dispatcher.Invoke(() =>
            {
                DeviceCodeLabel.Content = _deviceCode;
                DeviceCodeGrid.Visibility = Visibility.Visible;
            });
        }

        private void OnUserAuthFinished(object? _sender, EventArgs? _eventArgs)
        {
            Dispatcher.Invoke(() =>
            {
                DeviceCodeGrid.Visibility = Visibility.Collapsed;
            });
        }

        private void CancelButtonCLick(object sender, RoutedEventArgs e)
        {
            githubApi.CancelAuth();
        }
    }
}
