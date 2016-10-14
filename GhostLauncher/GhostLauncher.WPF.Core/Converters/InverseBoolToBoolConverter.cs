using System;
using System.Globalization;
using System.Windows.Data;

namespace GhostLauncher.WPF.Core.Converters
{
    public class InverseBoolToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
