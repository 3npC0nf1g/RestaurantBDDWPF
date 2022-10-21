using BibliRestaurant;
using System;
using System.Windows;
using System.Windows.Data;

namespace WpfInterface {
    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || value.ToString() == "") return DependencyProperty.UnsetValue;
            return ((Enum)value).GetDescription();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => null;
    }
}


