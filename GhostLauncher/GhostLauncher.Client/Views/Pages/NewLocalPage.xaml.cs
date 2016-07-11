using System.Windows;
using System.Windows.Controls;

namespace GhostLauncher.Client.Views.Pages
{
    /// <summary>
    /// Interaction logic for CreateInstanceWindow.xaml
    /// </summary>
    public partial class NewLocalPage : Page
    {
        public NewLocalPage()
        {
            InitializeComponent();
        }

        private void RadioButton_FolderLocation(object sender, RoutedEventArgs e)
        {
            if (FolderLocationComboBox == null || PathLocationTextBox == null || PathLocationButton == null)
                return;
            FolderLocationComboBox.IsEnabled = true;
            PathLocationTextBox.IsEnabled = false;
            PathLocationButton.IsEnabled = false;
        }

        private void RadioButton_PathLocation(object sender, RoutedEventArgs e)
        {
            if (FolderLocationComboBox == null || PathLocationTextBox == null || PathLocationButton == null)
                return;
            FolderLocationComboBox.IsEnabled = false;
            PathLocationTextBox.IsEnabled = true;
            PathLocationButton.IsEnabled = true;
        }
    }
}
