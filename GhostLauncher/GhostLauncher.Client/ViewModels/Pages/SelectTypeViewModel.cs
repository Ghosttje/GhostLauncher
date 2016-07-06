using GalaSoft.MvvmLight.Command;
using GhostLauncher.Client.Entities.Enums;
using GhostLauncher.Client.Events;
using GhostLauncher.Client.ViewModels.BaseViewModels;
using GhostLauncher.Client.Views.Pages;

namespace GhostLauncher.Client.ViewModels.Pages
{
    public class SelectTypeViewModel : BaseViewModel
    {
        #region Commands

        public RelayCommand AddInstanceCommand => GetCommand(OnNewInstance);

        public RelayCommand AddServerCommand => GetCommand(OnNewServer);

        #endregion

        public delegate void RaiseSelectedType(SelectTypeViewModel m, SelectedTypeArgs e);
        public event RaiseSelectedType SelectedTypeHandler;

        #region Constructors

        public SelectTypeViewModel() : base(new SelectTypePage())
        {

        }

        #endregion

        #region Command Events

        private void OnNewInstance()
        {
            if (SelectedTypeHandler == null)
                return;
            var args = new SelectedTypeArgs() { InstanceType = InstanceType.Local };
            SelectedTypeHandler(this, args);
        }

        private void OnNewServer()
        {
            if (SelectedTypeHandler == null)
                return;
            var args = new SelectedTypeArgs() { InstanceType = InstanceType.Remote };
            SelectedTypeHandler(this, args);
        }

        #endregion
    }
}