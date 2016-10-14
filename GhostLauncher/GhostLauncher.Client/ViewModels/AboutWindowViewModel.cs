using GhostLauncher.Client.Views;
using GhostLauncher.WPF.Core.BaseViewModels;

namespace GhostLauncher.Client.ViewModels
{
    public class AboutWindowViewModel : BaseWindowViewModel
    {
        public AboutWindowViewModel() : base(new AboutWindow())
        {
        }
    }
}
