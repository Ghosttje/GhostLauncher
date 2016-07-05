using System.Windows;
using GhostLauncher.Client.ViewModels;

namespace GhostLauncher.Client.Views
{
    /// <summary>
    /// Interaction logic for NewInstanceWindow.xaml
    /// </summary>
    public partial class NewInstanceWindow : Window
    {
        public NewInstanceWindow()
        {
            InitializeComponent();
            DataContext = new NewInstanceViewModel(this);
        }
    }
}
