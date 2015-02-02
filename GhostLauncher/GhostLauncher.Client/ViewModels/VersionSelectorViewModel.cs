using System.Collections.ObjectModel;
using System.Windows;
using GhostLauncher.Client.BL;
using GhostLauncher.Client.ViewModels.Commands;
using GhostLauncher.Core;
using GhostLauncher.Entities;

namespace GhostLauncher.Client.ViewModels
{
    public class VersionSelectorViewModel : NotifyPropertyChanged
    {
        public ObservableCollection<MinecraftVersion> VersionCollection
        {
            get { return _versionCollection; }
        }

        private MinecraftVersion _selectedVersion;
        private readonly Window _window;
        private RelayCommand _command;
        private readonly ObservableCollection<MinecraftVersion> _versionCollection;

        public VersionSelectorViewModel(Window window)
        {
            _window = window;
            _versionCollection = new ObservableCollection<MinecraftVersion>();
            ParseVersions();
        }

        private void ParseVersions()
        {
            VersionCollection.Clear();
            _selectedVersion = null;

            MasterManager.GetSingleton.VersionManager.Init();

            foreach (var result in MasterManager.GetSingleton.VersionManager.MinecraftVersions)
            {
                VersionCollection.Add(result);
            }
        }

        #region Setters / Getters

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

        public RelayCommand SelectCommand
        {
            get
            {
                _command = new RelayCommand(Select);
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

        #endregion

        #region CommandHandlers

        private void Select()
        {
            _window.DialogResult = true;
            _window.Close();
        }

        private void Close()
        {
            _window.DialogResult = false;
            _window.Close();
        }

        #endregion
    }
}
