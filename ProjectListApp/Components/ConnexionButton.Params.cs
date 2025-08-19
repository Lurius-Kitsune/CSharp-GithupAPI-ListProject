using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjectListApp.Components
{
    struct ButtonStyle
    {
        public Brush Background { get; set; }
        public Brush Foreground { get; set; }
        public Brush BorderBrush { get; set; }
        public Brush OpacityMask { get; set; }
    }
    
    partial class ConnexionButton : Button
    {
        [Category("Connexion")]
        public string ConnectedText
        {
            get => (string)GetValue(ConnectedTextProperty);
            set => SetValue(ConnectedTextProperty, value);
        }

        public static readonly DependencyProperty ConnectedTextProperty =
            DependencyProperty.Register(
                nameof(ConnectedText),
                typeof(string),
                typeof(ConnexionButton),
                new PropertyMetadata("Disconect"));

        [Category("Connexion")]
        public string DisconnectedText
        {
            get => (string)GetValue(DisconnectedTextProperty);
            set => SetValue(DisconnectedTextProperty, value);
        }

        public static readonly DependencyProperty DisconnectedTextProperty =
            DependencyProperty.Register(
                nameof(DisconnectedText),
                typeof(string),
                typeof(ConnexionButton),
                new PropertyMetadata("Connexion"));

        [Bindable(true)]
        [Category("Connexion")]
        public ButtonStyle ConnectedStyle
        {
            get => (ButtonStyle)GetValue(ConnectedStyleProperty);
            set => SetValue(ConnectedStyleProperty, value);
        }

        public static readonly DependencyProperty ConnectedStyleProperty =
            DependencyProperty.Register(
                nameof(ConnectedStyle),
                typeof(ButtonStyle),
                typeof(ConnexionButton),
                new PropertyMetadata(new ButtonStyle
                {
                    Background = Brushes.Green,
                    Foreground = Brushes.White,
                    BorderBrush = Brushes.DarkGreen,
                    OpacityMask = Brushes.LightGreen
                }));

        [Bindable(true)]
        [Category("Connexion")]
        public ButtonStyle DisconnectedStyle
        {
            get => (ButtonStyle)GetValue(DisconnectedStyleProperty);
            set => SetValue(DisconnectedStyleProperty, value);
        }

        public static readonly DependencyProperty DisconnectedStyleProperty =
            DependencyProperty.Register(
                nameof(DisconnectedStyle),
                typeof(ButtonStyle),
                typeof(ConnexionButton),
                new PropertyMetadata(new ButtonStyle
                {
                    Background = Brushes.Red,
                    Foreground = Brushes.White,
                    BorderBrush = Brushes.DarkRed,
                    OpacityMask = Brushes.LightPink
                }));
    }
}
