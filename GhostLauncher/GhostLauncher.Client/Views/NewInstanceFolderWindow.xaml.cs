using System.Windows;
using GhostLauncher.Client.ViewModels;

namespace GhostLauncher.Client.Views
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
