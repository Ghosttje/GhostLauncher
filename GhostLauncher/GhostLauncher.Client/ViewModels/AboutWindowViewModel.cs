using System.Windows;
using GhostLauncher.Client.ViewModels.BaseViewModels;
using GhostLauncher.Client.Views;

namespace GhostLauncher.Client.ViewModels
{
    public class AboutWindowViewModel : BaseWindowViewModel
    {
        public AboutWindowViewModel() : base(new AboutWindow())
        {
        }
    }
}
