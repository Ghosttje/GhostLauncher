using GalaSoft.MvvmLight.Command;
using GhostLauncher.Client.Tokens;
using GhostLauncher.Client.ViewModels.Settings;
using GhostLauncher.WPF.Core.BaseViewModels;

namespace GhostLauncher.Client.ViewModels.InstanceLocations
{
    public class AddInstanceLocationViewModel : BaseViewModel
    {
        #region Commands

        public RelayCommand AddLocationCommand => GetCommand(OnAddLocation);
        public RelayCommand CancelAddLocationCommand => GetCommand(OnCancelAddLocaton);

        #endregion

        #region Command Events

        private void OnAddLocation()
        {

        }

        private void OnCancelAddLocaton()
        {
            PublishMessage(MessagingTokens.ChangeSettingsContentView, typeof(SettingsViewModel));
        }

        #endregion
    }
}
