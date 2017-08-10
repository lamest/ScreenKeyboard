using System;
using System.Collections.Generic;
using System.Windows.Data;

namespace ScreenKeyboard.Converters
{
    class NumberButtonWidthConverter:IMultiValueConverter
    {
        //<Binding ElementName = "RowsItemsControl" Path="ItemsSource"/>
        //<Binding ElementName = "RowsItemsControl" Path="ActualWidth"/>
        public object Convert(object[] values, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(values[0] is List<Key>) || !(values[1] is double))
            {
                return "0";
            }

            //Margin="10"
            var margin = 0;

            var containerWidth = (double)values[1];
            if (containerWidth < margin)
            {
                return 0.ToString();
            }
            var buttons = (List<Key>)values[0];
            int maxCount = buttons.Count;

            double result = (containerWidth / maxCount) - 2 * margin;
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes,
            object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}

