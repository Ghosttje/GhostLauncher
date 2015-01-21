using System.Windows;
using GhostLauncher.Client.ViewModels;

namespace GhostLauncher.Client.Views.Windows
{
    /// <summary>
    /// Interaction logic for AddInstanceWindow.xaml
    /// </summary>
    public partial class AddInstanceWindow : Window
    {
        public AddInstanceWindow()
        {
            InitializeComponent();

            DataContext = new AddInstanceViewModel(this);
        }
    }
}
