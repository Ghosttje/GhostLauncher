using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Forms;
using GhostLauncher.Client.BL;
using GhostLauncher.Client.Entities.Configurations;
using GhostLauncher.Client.ViewModels.Commands;
using GhostLauncher.Client.Views.Windows;
using GhostLauncher.Core;
using GhostLauncher.Entities;

namespace GhostLauncher.Client.ViewModels
{
    public class NewLocalViewModel : NotifyPropertyChanged
    {
        private RelayCommand _command;
        private readonly Window _window;

        private string _name;
        private string _instancePath;
        private MinecraftVersion _selectedVersion;

        private ObservableCollection<InstanceFolder> _instanceFolders = new ObservableCollection<InstanceFolder>();
        private InstanceFolder _selectedFolder;

        private bool _isFolderLocation = true;
        private bool _isPathLocation;

        public NewLocalViewModel(Window window)
        {
            _window = window;

            foreach (var instanceFolder in MasterManager.GetSingleton.GetConfig().InstanceFolders)
            {
                _instanceFolders.Add(instanceFolder);
            }
        }

        #region Setters / Getters

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string InstancePath
        {
            get { return _instancePath; }
            set
            {
                _instancePath = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<InstanceFolder> InstanceFolders
        {
            get { return _instanceFolders; }
            set
            {
                _instanceFolders = value;
                OnPropertyChanged();
            }
        }

        public InstanceFolder SelectedFolder
        {
            get { return _selectedFolder; }
            set
            {
                _selectedFolder = value;
                OnPropertyChanged();
            }
        }

        public MinecraftVersion SelectedVersion
        {
            get { return _selectedVersion; }
            set
            {
                _selectedVersion = value;
                OnPropertyChanged();
            }
        }

        public bool IsFolderLocation
        {
            get { return _isFolderLocation; }
            set
            {
                _isFolderLocation = value;
                OnPropertyChanged();
            }
        }

        public bool IsPathLocation
        {
            get { return _isPathLocation; }
            set
            {
                _isPathLocation = value;
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
            _window.DialogResult = true;
            _window.Close();
        }

        private void Close()
        {
            _window.DialogResult = false;
            _window.Close();
        }

        private void SelectPath()
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                InstancePath = dialog.SelectedPath;
            }
        }

        private void SelectVersion()
        {
            var versionSelector = new VersionSelectorWindow { Owner = _window };
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