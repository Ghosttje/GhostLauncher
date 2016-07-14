using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace GhostLauncher.Client.Converters
{
    public class ResourceConverter : IValueConverter
    {
        private readonly ResourceDictionary _resourceDictionary;

        public ResourceConverter()
        {
            _resourceDictionary = new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/Resources/ResourceDictionary.xaml")
            };
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Style)_resourceDictionary[value];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (from object key in _resourceDictionary.Keys where _resourceDictionary[key] == value select key.ToString()).FirstOrDefault();
        }
    }
}
