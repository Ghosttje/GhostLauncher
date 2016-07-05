using System.Collections.ObjectModel;
using System.Windows;
using GhostLauncher.Client.BL;
using GhostLauncher.Client.Entities.Instances;
using GhostLauncher.Client.ViewModels.Commands;
using GhostLauncher.Client.Views;
using GhostLauncher.Core;

namespace GhostLauncher.Client.ViewModels
{
    public class MainViewModel : NotifyPropertyChanged
    {
        private RelayCommand _command;
        private readonly Window _window;
        private readonly ObservableCollection<Instance> _instanceCollection;
        private Instance _selectedInstance;
        
        public MainViewModel(Window window)
        {
            _window = window;
            _instanceCollection = new ObservableCollection<Instance>();

            RefreshInstances();
        }

        private void RefreshInstances()
        {
            _instanceCollection.Clear();
            foreach (var instance in Manager.GetSingleton.InstanceManager.Instances)
            {
                _instanceCollection.Add(instance);
            } 
        }

        #region Setters / Getters

        public ObservableCollection<Instance> InstanceCollection
        {
            get
            {
                return _instanceCollection;
            }
        }

        public Instance SelectedInstance
        {
            set
            {
                _selectedInstance = value;

            }
        }

        #endregion

        #region Commands

        public RelayCommand AddInstanceCommand
        {
            get
            {
                _command = new RelayCommand(AddInstance);
                return _command;
            }
        }

        public RelayCommand DeleteInstanceCommand
        {
            get
            {
                _command = new RelayCommand(DeleteInstance);
                return _command;
            }
        }

        public RelayCommand SettingsCommand
        {
            get
            {
                _command = new RelayCommand(Settings);
                return _command;
            }
        }

        public RelayCommand AboutCommand
        {
            get
            {
                _command = new RelayCommand(About);
                return _command;
            }
        }

        #endregion

        #region CommandHandlers

        private void AddInstance()
        {
            var newInstance = new NewInstanceWindow() {Owner = _window};
            newInstance.ShowDialog();
            if (newInstance.DialogResult.HasValue && newInstance.DialogResult.Value)
            {
                RefreshInstances();
            }
        }

        private void DeleteInstance()
        {
            var result = MessageBox.Show("Do you want to delete this instance?", "Delete instance", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes) return;
            Manager.GetSingleton.InstanceManager.DeleteInstance(_selectedInstance);
            _instanceCollection.Remove(_selectedInstance);
        }

        private void Settings()
        {
            new SettingsWindow() { Owner = _window }.Show();
        }

        private void About()
        {
            new AboutWindow() { Owner = _window }.Show();
        }

        public static void Close()
        {
            Manager.GetSingleton.CloseApp();
        }

        #endregion
    }
}