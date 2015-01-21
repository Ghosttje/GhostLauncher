using System.Windows;
using GhostLauncher.Client.ViewModels;

namespace GhostLauncher.Client.Views.Windows
{
    /// <summary>
    /// Interaction logic for VersionSelectorWindow.xaml
    /// </summary>
    public partial class VersionSelectorWindow : Window
    {
        public VersionSelectorWindow()
        {
            InitializeComponent();

            DataContext = new VersionSelectorViewModel(this);
        }
    }
}
