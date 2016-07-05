using System.Windows;
using GhostLauncher.Client.ViewModels.BaseViewModels;
using GhostLauncher.Client.Views;

namespace GhostLauncher.Client.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel() : base(new SettingsWindow())
        {
            
        }
    }
}
