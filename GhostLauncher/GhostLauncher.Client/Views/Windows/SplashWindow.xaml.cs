using System.Windows;
using GhostLauncher.Client.ResourceDictionaries;
using GhostLauncher.Client.ViewModels;

namespace GhostLauncher.Client.Views.Windows
{
    /// <summary>
    /// Interaction logic for SplashWindow.xaml
    /// </summary>
    public partial class SplashWindow : Window
    {
        public SplashWindow()
        {
            Resources.MergedDictionaries.Add(SharedDictionaryManager.SharedDictionary);
            InitializeComponent();
            DataContext = new SplashViewModel(this);
        }
    }
}
