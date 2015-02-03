using System;
using System.Windows;

namespace GhostLauncher.Client.ResourceDictionaries
{
    internal static class SharedDictionaryManager
    {
        internal static ResourceDictionary SharedDictionary
        {
            get
            {
                if (_sharedDictionary == null)
                {
                    Uri resourceLocater = new Uri("/ResourceDictionaries/ResourceDictionary.xaml", UriKind.Relative);

                    _sharedDictionary = (ResourceDictionary)Application.LoadComponent(resourceLocater);
                }

                return _sharedDictionary;
            }
        }

        private static ResourceDictionary _sharedDictionary;
    }
}
