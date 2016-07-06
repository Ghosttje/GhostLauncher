using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using GhostLauncher.Client.BL;
using GhostLauncher.Client.Entities.Instances;
using GhostLauncher.Client.ViewModels.BaseViewModels;
using GhostLauncher.Client.Views;

namespace GhostLauncher.Client.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Commands

        public RelayCommand AddInstanceCommand => GetCommand(OnAddInstance);

        public RelayCommand DeleteInstanceCommand => GetCommand(OnDeleteInstance);

        public RelayCommand SettingsCommand => GetCommand(OnSettings);

        public RelayCommand AboutCommand => GetCommand(OnAbout);

        #endregion

        #region Private Properties

        private readonly ObservableCollection<Instance> _instanceCollection;
        private Instance _selectedInstance;

        private NewInstanceViewModel _newInstanceViewModel;
        private SettingsViewModel _settingsViewModel;
        private AboutViewModel _aboutViewModel;

        #endregion

        #region Constructors

        public MainViewModel() : base(new MainWindow())
        {
            _instanceCollection = new ObservableCollection<Instance>();

            RefreshInstances();
        }

        #endregion

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

        #region Command Events

        private void OnAddInstance()
        {
            if (_newInstanceViewModel == null)
            {
                _newInstanceViewModel = new NewInstanceViewModel();
                _newInstanceViewModel.GetWindow().Owner = GetWindow();
            }
            _newInstanceViewModel.GetWindow().ShowDialog();
            var dialogResult = _newInstanceViewModel.GetWindow().DialogResult;
            if (dialogResult != null && dialogResult.Value)
            {
                RefreshInstances();
            }
        }

        private void OnDeleteInstance()
        {
            var result = MessageBox.Show("Do you want to delete this instance?", "Delete instance", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes) return;
            Manager.GetSingleton.InstanceManager.DeleteInstance(_selectedInstance);
            _instanceCollection.Remove(_selectedInstance);
        }

        private void OnSettings()
        {
            if (_settingsViewModel == null)
            {
                _settingsViewModel = new SettingsViewModel();
                _settingsViewModel.GetWindow().Owner = GetWindow();
            }
            _settingsViewModel.GetWindow().Show();
        }

        private void OnAbout()
        {
            if (_aboutViewModel == null)
            {
                _aboutViewModel = new AboutViewModel();
                _aboutViewModel.GetWindow().Owner = (Window)View;
            }
            _aboutViewModel.GetWindow().Show();
        }

        public static void Close()
        {
            Manager.GetSingleton.CloseApp();
        }

        #endregion
    }
}