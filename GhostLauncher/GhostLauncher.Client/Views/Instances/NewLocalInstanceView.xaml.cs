using System.Windows;

namespace GhostLauncher.Client.Views.Instances
{
    /// <summary>
    /// Interaction logic for CreateInstanceWindow.xaml
    /// </summary>
    public partial class NewLocalInstanceView
    {
        public NewLocalInstanceView()
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
