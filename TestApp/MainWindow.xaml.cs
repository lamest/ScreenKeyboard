using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsInput;
using ScreenKeyboard;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ScreenKeyboardControlViewModel _keyboardViewModel;

        public ScreenKeyboardControlViewModel KeyboardViewModel
        {
            get { return _keyboardViewModel; }
            set
            {
                _keyboardViewModel = value;
                OnPropertyChanged(nameof(KeyboardViewModel));
            }
        }

        public MainWindow()
        {
            KeyboardViewModel = new ScreenKeyboardControlViewModel(Layout.SymbolsDefault,
                new List<Layout>(2)
                {
                    Layout.RussianDefault,
                    Layout.EnglishDefault
                },
                Layout.NumbersDefault,
                null,
                null,
                new InputSimulator());

            InitializeComponent();



        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
