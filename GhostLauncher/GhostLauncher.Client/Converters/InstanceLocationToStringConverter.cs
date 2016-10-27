using System;
using System.Globalization;
using System.Windows.Data;
using GhostLauncher.Entities.Locations;

namespace GhostLauncher.Client.Converters
{
    public class InstanceLocationToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() == typeof(InstancesFolder))
            {
                return Properties.Resources.InstanceType_Folder;
            }
            if (value.GetType() == typeof(InstancePath))
            {
                return Properties.Resources.InstanceType_Path;
            }
            throw new NotSupportedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
