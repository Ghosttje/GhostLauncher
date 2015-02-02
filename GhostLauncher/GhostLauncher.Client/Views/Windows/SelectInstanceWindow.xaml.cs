using System.Windows;
using GhostLauncher.Client.ViewModels;

namespace GhostLauncher.Client.Views.Windows
{
    /// <summary>
    /// Interaction logic for AddInstanceWindow.xaml
    /// </summary>
    public partial class SelectInstanceWindow : Window
    {
        public SelectInstanceWindow()
        {
            InitializeComponent();

            DataContext = new SelectInstanceViewModel(this);
        }
    }
}
