using System.Windows;
using GhostLauncher.Client.ViewModels.BaseViewModels;
using GhostLauncher.Client.Views;

namespace GhostLauncher.Client.ViewModels
{
    public class SettingsWindowViewModel : BaseWindowViewModel
    {
        public SettingsWindowViewModel() : base(new SettingsWindow())
        {
        }
    }
}
