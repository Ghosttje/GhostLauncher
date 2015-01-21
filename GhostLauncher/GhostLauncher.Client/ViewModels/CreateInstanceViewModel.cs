using System.Windows;
using GhostLauncher.Client.ViewModels.Commands;
using GhostLauncher.Client.Views;
using GhostLauncher.Client.Views.Windows;
using GhostLauncher.Entities;

namespace GhostLauncher.Client.ViewModels
{
    public class CreateInstanceViewModel
    {
        private RelayCommand _command;
        private readonly Window _window;

        public MinecraftVersion MinecraftVersion { set; get; }

        public CreateInstanceViewModel(Window window)
        {
            _window = window;
        }

        #region Commands

        public RelayCommand CreateInstanceCommand
        {
            get
            {
                _command = new RelayCommand(CreateInstance);
                return _command;
            }
        }

        public RelayCommand SelectPathCommand
        {
            get
            {
                _command = new RelayCommand(SelectPath);
                return _command;
            }
        }

        public RelayCommand SelectVersionCommand
        {
            get
            {
                _command = new RelayCommand(SelectVersion);
                return _command;
            }
        }

        #endregion

        #region CommandHandlers

        private void CreateInstance()
        {
            
        }

        private void SelectPath()
        {

        }

        private void SelectVersion()
        {
            var versionSelector = new VersionSelectorWindow {Owner = _window};
            versionSelector.ShowDialog();
        }

        #endregion
    }
}