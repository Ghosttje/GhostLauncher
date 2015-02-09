using System.Windows;
using System.Windows.Input;
using GhostLauncher.Client.ResourceDictionaries;
using GhostLauncher.Client.ViewModels;

namespace GhostLauncher.Client.Views.Windows
{
    /// <summary>
    /// Interaction logic for CreateInstanceWindow.xaml
    /// </summary>
    public partial class NewLocalWindow : Window
    {
        public NewLocalWindow()
        {
            Resources.MergedDictionaries.Add(SharedDictionaryManager.SharedDictionary);
            InitializeComponent();
            DataContext = new NewLocalViewModel(this);
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
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
