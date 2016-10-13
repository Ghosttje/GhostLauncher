using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using GhostLauncher.Client.BL;
using GhostLauncher.Client.Entities.Instances;
using GhostLauncher.Client.Tokens;
using GhostLauncher.Client.ViewModels.BaseViewModels;
using GhostLauncher.Client.ViewModels.Instances;
using GhostLauncher.Client.Views;

namespace GhostLauncher.Client.ViewModels
{
    public class MainWindowViewModel : BaseWindowViewModel
    {
        #region Commands

        public RelayCommand AddInstanceCommand => GetCommand(OnAddInstance);

        public RelayCommand DeleteInstanceCommand => GetCommand(OnDeleteInstance);

        public RelayCommand SettingsCommand => GetCommand(OnSettings);

        public RelayCommand AboutCommand => GetCommand(OnAbout);

        public RelayCommand CloseCommand => GetCommand(OnClose);

        #endregion

        #region Private Properties

        private readonly ObservableCollection<Instance> _instanceCollection;
        private Instance _selectedInstance;

        
        private SettingsWindowViewModel _settingsWindowViewModel;
        private AboutWindowViewModel _aboutWindowViewModel;

        private InstanceOverviewViewModel _instanceOverviewViewModel;
        private NewInstanceViewModel _instanceViewModel;

        #endregion

        #region Properties

        public BaseViewModel MainContentViewModel
        {
            get { return GetPropertyValue<BaseViewModel>(); }
            set { SetPropertyValue(value); }
        }

        #endregion

        #region Constructors

        public MainWindowViewModel(Window window) : base(window)
        {
            _instanceOverviewViewModel = new InstanceOverviewViewModel();
            MainContentViewModel = _instanceOverviewViewModel;

            //_instanceCollection = new ObservableCollection<Instance>();
            //RefreshInstances();

            Subscribe();
        }

        #endregion

        #region Subscribers

        private void Subscribe()
        {
            SubscribeForMessage<BaseViewModel>(MessagingTokens.ChangeContentView, OnChangeContentView);
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

        public ObservableCollection<Instance> InstanceCollection => _instanceCollection;

        public Instance SelectedInstance
        {
            set
            {
                _selectedInstance = value;

            }
        }

        #endregion

        #region Messaging Events

        private void OnChangeContentView(BaseViewModel viewModel)
        {
            MainContentViewModel = viewModel;
        }

        #endregion

        #region Command Events

        private void OnAddInstance()
        {
            if (_instanceViewModel == null)
            {
                _instanceViewModel = new NewInstanceViewModel();
            }
            MainContentViewModel = _instanceViewModel;

            //_newInstanceViewModel.GetWindow().ShowDialog();
            //var dialogResult = _newInstanceViewModel.GetWindow().DialogResult;
            //if (dialogResult != null && dialogResult.Value)
            //{
            //    RefreshInstances();
            //}
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
            //if (_settingsWindowViewModel == null)
            //{
            //    _settingsWindowViewModel = new SettingsWindowViewModel();
            //    _settingsWindowViewModel.GetWindow().Owner = GetWindow();
            //}
            //_settingsWindowViewModel.GetWindow().Show();
        }

        private void OnAbout()
        {
            //if (_aboutWindowViewModel == null)
            //{
            //    var window = new AboutWindow();
            //    window.Owner
            //    _aboutWindowViewModel = new AboutWindowViewModel();
            //    _aboutWindowViewModel.GetWindow().Owner = (Window)View;
            //}
            //_aboutWindowViewModel.GetWindow().Show();
        }

        public static void OnClose()
        {
            Manager.GetSingleton.CloseApp();
        }

        #endregion
    }
}