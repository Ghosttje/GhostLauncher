using System.Windows;
using GhostLauncher.Client.ViewModels.BaseViewModels;
using GhostLauncher.Client.Views;

namespace GhostLauncher.Client.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel() : base(new AboutWindow())
        {

        }
    }
}
