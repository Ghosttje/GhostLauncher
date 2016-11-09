using GalaSoft.MvvmLight.Command;
using GhostLauncher.Client.Tokens;
using GhostLauncher.Client.ViewModels.Settings;
using GhostLauncher.WPF.Core.BaseViewModels;

namespace GhostLauncher.Client.ViewModels.InstanceLocationWizard
{
    public class SelectInstanceLocationTypeViewModel : BaseViewModel
    {
        #region Commands

        public RelayCommand NewFolderLocationCommand => GetCommand(OnNewFolderLocation);
        public RelayCommand NewPathLocationCommand => GetCommand(OnNewPathLocation);
        public RelayCommand CancelAddLocationCommand => GetCommand(OnCancelAddLocaton);

        #endregion

        #region Command Events

        private void OnNewFolderLocation()
        {
            PublishMessage(MessagingTokens.ChangeSettingsContentView, typeof(AddInstanceLocationViewModel));
        }

        private void OnNewPathLocation()
        {
            PublishMessage(MessagingTokens.ChangeSettingsContentView, typeof(AddInstanceLocationViewModel));
        }

        private void OnCancelAddLocaton()
        {
            PublishMessage(MessagingTokens.ChangeSettingsContentView, typeof(SettingsViewModel));
        }

        #endregion
    }
}
