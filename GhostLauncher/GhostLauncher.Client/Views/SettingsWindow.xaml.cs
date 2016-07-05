using System.Windows;
using GhostLauncher.Client.ViewModels;

namespace GhostLauncher.Client.Views
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow
    {
        public SettingsWindow()
        {
            InitializeComponent();

            DataContext = new SettingsViewModel(this);
        }
    }
}
