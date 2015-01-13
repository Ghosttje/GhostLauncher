using System.Windows;
using System.Windows.Input;
using GhostLauncher.Client.ViewModels;

namespace GhostLauncher.Client.Views
{
    /// <summary>
    /// Interaction logic for CreateInstanceWindow.xaml
    /// </summary>
    public partial class CreateInstanceWindow : Window
    {
        public CreateInstanceWindow()
        {
            InitializeComponent();

            DataContext = new CreateInstanceViewModel(this);
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}
