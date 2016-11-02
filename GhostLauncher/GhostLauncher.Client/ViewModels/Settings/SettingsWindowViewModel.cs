using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using GhostLauncher.Client.Factories;
using GhostLauncher.Client.Tokens;
using GhostLauncher.Client.ViewModels.Settings.Interfaces;
using GhostLauncher.Client.Views.Settings;
using GhostLauncher.WPF.Core.Attributes;
using GhostLauncher.WPF.Core.BaseViewModels;

namespace GhostLauncher.Client.ViewModels.Settings
{
    public class SettingsWindowViewModel : BaseWindowViewModel
    {
        #region Commands

        public RelayCommand OkCommand => GetCommand(OnOk);
        public RelayCommand CancelCommand => GetCommand(OnCancel);
        public RelayCommand DefaultCommand => GetCommand(OnDefault);
        public RelayCommand RestartCommand => GetCommand(OnRestart);

        #endregion

        #region Properties

        public List<string> SettingItems
        {
            get { return GetPropertyValue<List<string>>(); }
            set { SetPropertyValue(value); }
        }

        public string SelectedSettingItem
        {
            get { return GetPropertyValue<string>(); }
            set { SetPropertyValue(value); }
        }

        [NotifiesOn(nameof(SelectedSettingItem))]
        public ISettingsViewModel CurrentPageViewModel => GetSettingsViewModel(SelectedSettingItem);

        private List<ISettingsViewModel> CachedSettingViewModels { get; set; }

        public bool IsRestartRequired
        {
            get { return GetPropertyValue<bool>(); }
            set { SetPropertyValue(value); }
        }

        #endregion

        #region Constructors

        public SettingsWindowViewModel(string settingName = null) : base(new SettingsWindow())
        {
            CachedSettingViewModels = new List<ISettingsViewModel>();
            SettingItems = SettingsFactory.GetSettings();
            SelectedSettingItem = settingName == null
                ? SettingItems.FirstOrDefault()
                : SettingItems.FirstOrDefault(x => x == settingName);
            RegisterSubscribers();
        }

        #endregion

        #region Event subscriptions

        private void RegisterSubscribers()
        {
            SubscribeForMessage<bool>(MessagingTokens.SettingsRestartRequired, message => IsRestartRequired = message);
            SubscribeForMessage<string>(MessagingTokens.ChangeSettingsView, name => SelectedSettingItem = name);
        }

        #endregion

        #region Functionality

        public ISettingsViewModel GetSettingsViewModel(string name)
        {
            var viewModel = CachedSettingViewModels.SingleOrDefault(x => x.GetType() == SettingsFactory.GetType(name));
            if (viewModel != null)
            {
                return viewModel;
            }
            var settingsViewModel = SettingsFactory.Create(name);
            CachedSettingViewModels.Add(settingsViewModel);
            return settingsViewModel;
        }

        private void SaveSettings()
        {
            foreach (var settingsViewModel in CachedSettingViewModels.Where(x => x.HasChanges()))
            {
                settingsViewModel.ApplySettings();
            }

            Properties.Settings.Default.Save();
        }

        private void CloseAndReload()
        {
            Properties.Settings.Default.Reload();
            View.Close();
        }

        #endregion

        #region Command Events

        private void OnOk()
        {
            SaveSettings();
            View.Close();
        }

        private void OnCancel()
        {
            if (CachedSettingViewModels.Any(x => x.HasChanges()))
            {
                var result = MessageBox.Show("Are you sure you wanna discard all changes?", "Discard all changes?",
                    MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
            }
            CloseAndReload();
        }

        private void OnDefault()
        {
            Properties.Settings.Default.Reset();
        }

        private void OnRestart()
        {
            SaveSettings();
            Application.Current.Shutdown();
            System.Windows.Forms.Application.Restart();
        }

        #endregion
    }
}
