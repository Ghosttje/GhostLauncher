using System.Windows;
using GhostLauncher.Client.ViewModels.Windows;

namespace GhostLauncher.Client.Views.Windows
{
    /// <summary>
    /// Interaction logic for NewFolderWindow.xaml
    /// </summary>
    public partial class NewInstanceFolderWindow : Window
    {
        public NewInstanceFolderWindow()
        {
            InitializeComponent();
            DataContext = new NewInstanceFolderViewModel(this);
        }
    }
}
