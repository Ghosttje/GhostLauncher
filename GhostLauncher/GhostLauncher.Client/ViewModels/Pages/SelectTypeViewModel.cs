using GhostLauncher.Client.Entities.Enums;
using GhostLauncher.Client.Events;
using GhostLauncher.Client.ViewModels.Commands;

namespace GhostLauncher.Client.ViewModels.Pages
{
    public class SelectTypeViewModel
    {
        private RelayCommand _command;

        public delegate void RaiseSelectedType(SelectTypeViewModel m, SelectedTypeArgs e);
        public event RaiseSelectedType SelectedTypeHandler;

        #region Commands

        public RelayCommand AddInstanceCommand
        {
            get
            {
                _command = new RelayCommand(NewInstance);
                return _command;
            }
        }

        public RelayCommand AddServerCommand
        {
            get
            {
                _command = new RelayCommand(NewServer);
                return _command;
            }
        }

        #endregion

        #region CommandHandlers

        private void NewInstance()
        {
            if (SelectedTypeHandler == null)
                return;
            var args = new SelectedTypeArgs() { InstanceType = InstanceType.Local };
            SelectedTypeHandler(this, args);
        }

        private void NewServer()
        {
            if (SelectedTypeHandler == null)
                return;
            var args = new SelectedTypeArgs() { InstanceType = InstanceType.Remote };
            SelectedTypeHandler(this, args);
        }

        #endregion
    }
}