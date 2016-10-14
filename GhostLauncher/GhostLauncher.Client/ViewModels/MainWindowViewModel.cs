using System.Windows;
using GalaSoft.MvvmLight.Command;
using GhostLauncher.Client.Tokens;
using GhostLauncher.Client.ViewModels.Instances;
using GhostLauncher.Client.ViewModels.Settings;
using GhostLauncher.WPF.Core.BaseViewModels;

namespace GhostLauncher.Client.ViewModels
{
    public class MainWindowViewModel : BaseWindowViewModel
    {
        #region Commands

        public RelayCommand AddInstanceCommand => GetCommand(OnAddInstance);

        public RelayCommand SettingsCommand => GetCommand(OnSettings);

        public RelayCommand AboutCommand => GetCommand(OnAbout);

        public RelayCommand CloseCommand => GetCommand(OnClose);

        #endregion

        #region Private Properties

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

            Subscribe();
        }

        #endregion

        #region Subscribers

        private void Subscribe()
        {
            SubscribeForMessage<BaseViewModel>(MessagingTokens.ChangeContentView, OnChangeContentView);
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
        }

        private void OnSettings()
        {
            if (_settingsWindowViewModel == null)
            {
                _settingsWindowViewModel = new SettingsWindowViewModel();
                _settingsWindowViewModel.GetWindow().Owner = GetWindow();
            }
            _settingsWindowViewModel.GetWindow().Show();
        }

        private void OnAbout()
        {
            if (_aboutWindowViewModel == null)
            {
                _aboutWindowViewModel = new AboutWindowViewModel();
                _aboutWindowViewModel.GetWindow().Owner = (Window)View;
            }
            _aboutWindowViewModel.GetWindow().Show();
        }

        public static void OnClose()
        {
            //Manager.GetSingleton.CloseApp();
        }

        #endregion
    }
}