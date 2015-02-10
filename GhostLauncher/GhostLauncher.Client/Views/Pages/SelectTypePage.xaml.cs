using System.Windows.Controls;
using GhostLauncher.Client.ResourceDictionaries;
using GhostLauncher.Client.ViewModels.Pages;

namespace GhostLauncher.Client.Views.Pages
{
    /// <summary>
    /// Interaction logic for AddInstanceWindow.xaml
    /// </summary>
    public partial class SelectTypePage : Page
    {
        public SelectTypePage()
        {
            Resources.MergedDictionaries.Add(SharedDictionaryManager.SharedDictionary);
            InitializeComponent();
            DataContext = new SelectTypeViewModel();
        }
    }
}
