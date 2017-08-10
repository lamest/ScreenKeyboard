using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WindowsInput;
using WindowsInput.Native;

namespace ScreenKeyboard
{
    public enum CapsState
    {
        Off,
        SingleTime,
        On
    }

    public sealed class ScreenKeyboardControlViewModel : INotifyPropertyChanged
    {
        public ScreenKeyboardControlViewModel(Layout symbolBlock, List<Layout> languageBlocks, Layout numbersBlock,
            List<Layout> additionalBlocks, List<string> quickAccessPanelLayout, IInputSimulator inputSimulator)
        {
            _inputSimulator = inputSimulator;

            RegisterKeyInputCommand = new DelegateCommand(RegisterKeyInputExecute);
            ChangeTabCommand = new DelegateCommand(ChangeTabExecute);

            TabsButtons = new List<string>();
            LanguageBlocks = languageBlocks;
            InitKeyInputCommands(LanguageBlocks);

            CurrentLayout = LanguageBlocks[0];
            SymbolBlock = symbolBlock;
            InitKeyInputCommands(new List<Layout>(1) {SymbolBlock});

            NumbersBlock = numbersBlock;
            InitKeyInputCommands(new List<Layout>(1) {NumbersBlock});

            IsLangMode = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void InitKeyInputCommands(List<Layout> blocks)
        {
            foreach (var block in blocks)
                block.Rows.ForEach(x => x.ForEach(y => y.InputCommand = RegisterKeyInputCommand));
        }

        private void RegisterKeyInputExecute(object obj)
        {
            var inputKey = obj as Key;
            if (inputKey != null)
            {
                var inputStr = string.Empty;
                switch (CapslockState)
                {
                    case CapsState.SingleTime:
                        inputStr = inputKey.CapitalInput;
                        CapslockState = CapsState.Off;
                        break;
                    case CapsState.On:
                        inputStr = inputKey.CapitalInput;
                        break;
                    case CapsState.Off:
                        inputStr = inputKey.Input;
                        break;
                }
                _inputSimulator.Keyboard.TextEntry(inputStr);
            }
            else
            {
                var buttonParam = obj as string;
                switch (buttonParam)
                {
                    case "space":
                        _inputSimulator.Keyboard.TextEntry(" ");
                        break;
                    case "BS":
                        _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BACK);
                        break;
                    case "capslock":
                        CapslockSwitch();
                        break;
                    case "enter":
                        _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                        break;
                    case "lang":
                        SwitchLang();
                        break;
                    case "symbols":
                        SwitchSymbols();
                        break;
                    default:
                        _inputSimulator.Keyboard.TextEntry(buttonParam);
                        break;
                }
            }
        }

        private void SwitchLang()
        {
            var indx = LanguageBlocks.FindIndex(x => x.Name == CurrentLayout.Name);
            CurrentLayout = indx == LanguageBlocks.Count - 1 ? LanguageBlocks[0] : LanguageBlocks[indx + 1];
        }

        private void SwitchSymbols()
        {
            if (_prevLayout == null)
            {
                _prevLayout = CurrentLayout;
                CurrentLayout = SymbolBlock;
                IsLangMode = false;
            }
            else
            {
                CurrentLayout = _prevLayout;
                _prevLayout = null;
                IsLangMode = true;
            }
        }

        private void CapslockSwitch()
        {
            switch (CapslockState)
            {
                case CapsState.Off:
                    CapslockState = CapsState.SingleTime;
                    break;
                case CapsState.SingleTime:
                    CapslockState = CapsState.On;
                    break;
                case CapsState.On:
                    CapslockState = CapsState.Off;
                    break;
            }
        }

        private void ChangeTabExecute(object obj)
        {
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Properties

        private Layout _currentLayout;
        private IInputSimulator _inputSimulator;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public Layout CurrentLayout
        {
            get => _currentLayout;
            set => SetProperty(ref _currentLayout, value);
        }

        private Layout _numbersBlock;

        public Layout NumbersBlock
        {
            get => _numbersBlock;
            set => SetProperty(ref _numbersBlock, value);
        }

        private bool _isLangMode;

        public bool IsLangMode
        {
            get => _isLangMode;
            set => SetProperty(ref _isLangMode, value);
        }

        private Layout _prevLayout;
        public Layout SymbolBlock { get; set; }

        public List<Layout> LanguageBlocks { get; }
        public List<string> TabsButtons { get; }
        public ICommand RegisterKeyInputCommand { get; }
        public ICommand ChangeTabCommand { get; }

        private ICommand _hideKeyboardCommand;

        public ICommand HideKeyboardCommand
        {
            get => _hideKeyboardCommand;

            set
            {
                HideButtonVisible = value != null;
                SetProperty(ref _hideKeyboardCommand, value);
            }
        }

        private bool _hideButtonVisible;

        public bool HideButtonVisible
        {
            get => _hideButtonVisible;

            set => SetProperty(ref _hideButtonVisible, value);
        }

        private CapsState _capslockState;

        public CapsState CapslockState
        {
            get => _capslockState;

            set => SetProperty(ref _capslockState, value);
        }

        #endregion
    }
}