using GhostLauncher.Client.Views;
using GhostLauncher.WPF.Core.BaseViewModels;

namespace GhostLauncher.Client.ViewModels
{
    public class SettingsWindowViewModel : BaseWindowViewModel
    {
        public SettingsWindowViewModel() : base(new SettingsWindow())
        {
        }
    }
}
