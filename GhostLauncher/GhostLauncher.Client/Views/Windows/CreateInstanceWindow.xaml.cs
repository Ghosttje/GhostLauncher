using System.Windows;
using System.Windows.Input;
using GhostLauncher.Client.ResourceDictionaries;
using GhostLauncher.Client.ViewModels;

namespace GhostLauncher.Client.Views.Windows
{
    /// <summary>
    /// Interaction logic for CreateInstanceWindow.xaml
    /// </summary>
    public partial class CreateInstanceWindow : Window
    {
        public CreateInstanceWindow()
        {
            Resources.MergedDictionaries.Add(SharedDictionaryManager.SharedDictionary);
            InitializeComponent();
            DataContext = new CreateInstanceViewModel(this);
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}
