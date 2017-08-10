using System;
using System.Windows.Data;

namespace ScreenKeyboard.Converters
{
    class NumberButtonHeightConverter:IMultiValueConverter
    {
        //<Binding ElementName = "RowsItemsControl" Path="ItemsSource"/>
        //<Binding ElementName = "RowsItemsControl" Path="ActualWidth"/>
        public object Convert(object[] values, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(values[1] is double))
            {
                return "0";
            }

            //Margin="10"
            var margin = 0;

            var containerHeigth = (double)values[1];
            if (containerHeigth < margin)
            {
                return 0;
            }

            return containerHeigth;
        }

        public object[] ConvertBack(object value, Type[] targetTypes,
            object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}
