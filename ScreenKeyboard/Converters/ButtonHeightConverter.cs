using System;
using System.Collections.Generic;
using System.Windows.Data;

namespace ScreenKeyboard.Converters
{
    public class ButtonHeightConverter : IMultiValueConverter
    {
                                        //<Binding ElementName = "RowsItemsControl" Path="ItemsSource"/>
                                        //<Binding ElementName = "RowsItemsControl" Path="ActualHeight"/>
        public object Convert(object[] values, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(values[1] is double) || !(values[0] is List<List<Key>>))
            {
                return 0;
            }

            //Margin="10"
            var margin = 0;
            var containerHeigth = (double)values[1];
            if (containerHeigth < margin)
            {
                return 0;
            }
            var buttons = (List<List<Key>>)values[0];

            double result = (containerHeigth / buttons.Count) - 2 * margin;
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes,
            object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}
