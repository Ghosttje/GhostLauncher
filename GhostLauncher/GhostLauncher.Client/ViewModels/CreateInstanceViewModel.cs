using System.Activities.Expressions;
using System.Windows;
using System.Windows.Forms;
using GhostLauncher.Client.BL;
using GhostLauncher.Client.Entities;
using GhostLauncher.Client.Entities.Configurations;
using GhostLauncher.Client.ViewModels.Commands;
using GhostLauncher.Client.Views.Windows;
using GhostLauncher.Core;
using GhostLauncher.Entities;
using Microsoft.Win32;

namespace GhostLauncher.Client.ViewModels
{
    public class CreateInstanceViewModel : NotifyPropertyChanged
    {
        private RelayCommand _command;
        private readonly Window _window;

        private string _name;
        private string _instancePath;
        private MinecraftVersion _selectedVersion;

        public CreateInstanceViewModel(Window window)
        {
            _window = window;
        }

        #region Setters / Getters

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string InstancePath
        {
            get
            {
                return _instancePath;
            }
            set
            {
                _instancePath = value;
                OnPropertyChanged();
            }
        }

        public MinecraftVersion SelectedVersion
        {
            get
            {
                return _selectedVersion;
            }
            set
            {
                _selectedVersion = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public RelayCommand CreateInstanceCommand
        {
            get
            {
                _command = new RelayCommand(CreateInstance);
                return _command;
            }
        }

        public RelayCommand CloseCommand
        {
            get
            {
                _command = new RelayCommand(Close);
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
            var configInstance = new ClientInstance() {Name = _name, Path = _instancePath};
            MasterManager.GetSingleton.InstanceManager.CreateInstance(configInstance);
            _window.Close();
        }

        private void Close()
        {
            _window.Close();
        }

        private void SelectPath()
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _instancePath = dialog.SelectedPath;
            }
        }

        private void SelectVersion()
        {
            var versionSelector = new VersionSelectorWindow {Owner = _window};
            versionSelector.ShowDialog();

            if (versionSelector.DialogResult.HasValue && versionSelector.DialogResult.Value)
            {
                var versionSelectorViewModel = (VersionSelectorViewModel)versionSelector.DataContext;
                SelectedVersion = versionSelectorViewModel.SelectedVersion;
            }
        }

        #endregion
    }
}