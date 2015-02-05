using System.Windows;
using GhostLauncher.Client.Entities.Enums;
using GhostLauncher.Client.ViewModels.Commands;

namespace GhostLauncher.Client.ViewModels
{
    public class SelectTypeViewModel
    {
        private RelayCommand _command;
        private Window _window;

        public InstanceType InstanceType { get; set; }

        public SelectTypeViewModel(Window window)
        {
            _window = window;
        }

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
            InstanceType = InstanceType.Local;
            _window.DialogResult = true;
            _window.Close();
        }

        private void NewServer()
        {
            InstanceType = InstanceType.Remote;
            _window.DialogResult = true;
            _window.Close();
        }

        #endregion
    }
}