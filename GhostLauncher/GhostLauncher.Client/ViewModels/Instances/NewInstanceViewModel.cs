using GalaSoft.MvvmLight.Command;
using GhostLauncher.Client.Tokens;
using GhostLauncher.Client.ViewModels.BaseViewModels;

namespace GhostLauncher.Client.ViewModels.Instances
{
    public class NewInstanceViewModel : BaseViewModel
    {
        #region Commands

        public RelayCommand AddInstanceCommand => GetCommand(OnNewInstance);
        public RelayCommand AddServerCommand => GetCommand(OnNewServer);
        public RelayCommand CancelCommand => GetCommand(OnCancel);

        #endregion

        #region Command Events

        private void OnCancel()
        {
            
        }

        private void OnNewInstance()
        {
            PublishMessage<BaseViewModel>(MessagingTokens.ChangeContentView, new NewLocalInstanceViewModel());
            //if (SelectedTypeHandler == null)
            //    return;
            //var args = new SelectedTypeArgs() { InstanceType = InstanceType.Local };
            //SelectedTypeHandler(this, args);
        }

        private void OnNewServer()
        {
            //if (SelectedTypeHandler == null)
            //    return;
            //var args = new SelectedTypeArgs() { InstanceType = InstanceType.Remote };
            //SelectedTypeHandler(this, args);
        }

        #endregion


    }
}
