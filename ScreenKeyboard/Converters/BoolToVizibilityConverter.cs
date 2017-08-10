using System;
using System.Windows;
using System.Windows.Data;

namespace ScreenKeyboard.Converters
{
    internal class BoolToVizibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            var isVisible = (bool) value;
            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetTypes,
            object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}

