using System.Windows;
using GhostLauncher.Client.ViewModels;

namespace GhostLauncher.Client.Views
{
    /// <summary>
    /// Interaction logic for NewFolderWindow.xaml
    /// </summary>
    public partial class NewInstanceFolderWindow
    {
        public NewInstanceFolderWindow()
        {
            InitializeComponent();
            DataContext = new NewInstanceFolderViewModel(this);
        }
    }
}
