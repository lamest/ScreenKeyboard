using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ScreenKeyboard
{
    public sealed class Key : INotifyPropertyChanged
    {
        private ICommand _inputCommand;

        public Key(string letter, string capitalLetter)
        {
            View = letter;
            Input = letter;
            CapitalView = capitalLetter;
            CapitalInput = capitalLetter;
        }

        public Key(string letter)
        {
            View = letter;
            Input = letter;
            CapitalView = letter;
            CapitalInput = letter;
        }

        public string View { get; }
        public string CapitalView { get; }
        public string Input { get; }
        public string CapitalInput { get; }

        public ICommand InputCommand
        {
            get => _inputCommand;
            set
            {
                _inputCommand = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}