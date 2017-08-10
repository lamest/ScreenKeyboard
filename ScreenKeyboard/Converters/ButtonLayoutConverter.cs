using System;
using System.Windows.Data;

namespace ScreenKeyboard.Converters
{
    public class ButtonLayoutConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(values[1] is string) || !(values[0] is string))
            {
                return "err";
            }

            var letter = (string) values[0];
            var capitalLetter = (string) values[1];
            //var letter = (string) values[0];
            //var capitalLetter = (string) values[1];
            var capsLockStatus = (CapsState) values[2];
            switch (capsLockStatus)
            {
                case CapsState.Off:
                    return letter;
                case CapsState.SingleTime:
                    return capitalLetter;
                case CapsState.On:
                    return capitalLetter;
                default:
                    return "err";
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes,
            object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}
