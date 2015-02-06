using System.Windows;
using GhostLauncher.Client.ViewModels;

namespace GhostLauncher.Client.Views.Windows
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();

            DataContext = new SettingsViewModel(this);
        }
    }
}
