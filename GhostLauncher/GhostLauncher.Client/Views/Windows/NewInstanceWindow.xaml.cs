using System.Windows;
using GhostLauncher.Client.ViewModels.Windows;

namespace GhostLauncher.Client.Views.Windows
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
