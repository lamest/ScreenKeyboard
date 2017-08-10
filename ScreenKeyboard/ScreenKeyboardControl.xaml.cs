using System.Windows;
using System.Windows.Controls;

namespace ScreenKeyboard
{
    /// <summary>
    ///     Interaction logic for Keyboard.xaml
    /// </summary>
    public partial class ScreenKeyboardControl : UserControl
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(ScreenKeyboardControlViewModel), typeof(ScreenKeyboardControl));

        public ScreenKeyboardControl()
        {
            InitializeComponent();
        }

        public ScreenKeyboardControlViewModel ViewModel
        {
            get => (ScreenKeyboardControlViewModel) GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}