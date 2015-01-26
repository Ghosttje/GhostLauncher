using System.Collections.ObjectModel;
using System.Windows;
using GhostLauncher.Client.Services;
using GhostLauncher.Client.ViewModels.Commands;
using GhostLauncher.Core;
using GhostLauncher.Entities;

namespace GhostLauncher.Client.ViewModels
{
    public class VersionSelectorViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<MinecraftVersion> _instanceCollection = new ObservableCollection<MinecraftVersion>();
        private MinecraftVersion _selectedInstance;
        private readonly Window _window;
        private RelayCommand _command;

        public VersionSelectorViewModel(Window window)
        {
            _window = window;
            var results = JsonService.ParseMinecraftVersions();
            
            foreach (var result in results) 
            {
                _instanceCollection.Add(result);
            }
        }

        #region Setters / Getters

        public ObservableCollection<MinecraftVersion> InstanceCollection
        {
            set { _instanceCollection = value; }
            get { return _instanceCollection; }
        }

        public MinecraftVersion SelectedInstance
        {
            get
            {
                return _selectedInstance;
            }
            set
            {
                _selectedInstance = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public RelayCommand CreateInstanceCommand
        {
            get
            {
                _command = new RelayCommand(SelectCommand);
                return _command;
            }
        }

        #endregion

        #region CommandHandlers

        private void SelectCommand()
        {
            _window.DialogResult = true;
            _window.Close();
        }

        #endregion
    }
}
