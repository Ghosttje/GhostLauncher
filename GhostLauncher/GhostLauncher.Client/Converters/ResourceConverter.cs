using System;
using System.Globalization;
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
            foreach (var key in _resourceDictionary.Keys)
            {
                if (_resourceDictionary[key] == value)
                {
                    return key.ToString();
                }
            }
            return null;
        }
    }
}
