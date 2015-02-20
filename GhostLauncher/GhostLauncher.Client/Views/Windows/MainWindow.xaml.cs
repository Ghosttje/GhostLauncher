using System.Windows;
using GhostLauncher.Client.ResourceDictionaries;
using GhostLauncher.Client.ViewModels.Windows;

namespace GhostLauncher.Client.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Resources.MergedDictionaries.Add(SharedDictionaryManager.SharedDictionary);
            InitializeComponent();
            var viewmodel = new MainViewModel(this);
            Closed += (sender, e) => viewmodel.Close();
            DataContext = viewmodel;
        }
    }
}
