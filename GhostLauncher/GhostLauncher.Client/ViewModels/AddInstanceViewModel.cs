using System.Windows;
using GhostLauncher.Client.ViewModels.Commands;
using GhostLauncher.Client.Views;
using GhostLauncher.Client.Views.Windows;

namespace GhostLauncher.Client.ViewModels
{
    public class AddInstanceViewModel
    {
        private RelayCommand _command;
        private readonly Window _window;

        public AddInstanceViewModel(Window window)
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
            var createInstanceWindow = new CreateInstanceWindow { Owner = _window.Owner };
            createInstanceWindow.Show();
            _window.Close();
        }

        private void NewServer()
        {

        }

        #endregion
    }
}