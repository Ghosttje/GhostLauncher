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
        private MinecraftVersion _selectedVersion;
        private readonly Window _window;
        private RelayCommand _command;

        public VersionSelectorViewModel(Window window)
        {
            _window = window;
            VersionCollection = new ObservableCollection<MinecraftVersion>();
            ParseVersions();
        }

        private void ParseVersions()
        {
            VersionCollection.Clear();
            _selectedVersion = null;

            Manager.GetSingleton.VersionManager.Init();

            foreach (var result in Manager.GetSingleton.VersionManager.MinecraftVersions)
            {
                VersionCollection.Add(result);
            }
        }

        #region Setters / Getters

        public ObservableCollection<MinecraftVersion> VersionCollection { get; private set; }

        public MinecraftVersion SelectedVersion
        {
            get { return GetPropertyValue<MinecraftVersion>(); }
            set { SetPropertyValue(value); }
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
