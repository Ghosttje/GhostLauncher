using System;
using System.Collections.Generic;
using System.Windows;
using GhostLauncher.Client.Factories;
using GhostLauncher.Client.Tokens;
using GhostLauncher.Client.ViewModels.InstanceLocations;
using GhostLauncher.Client.ViewModels.Settings.Interfaces;
using GhostLauncher.Client.Views.Settings;
using GhostLauncher.WPF.Core.BaseViewModels;

namespace GhostLauncher.Client.ViewModels.Settings
{
    public class SettingsWindowViewModel : BaseWindowViewModel
    {
        #region Private Properties

        private SettingsViewModel _settingsViewModel;
        private AddInstanceLocationViewModel _addLocationViewModel;

        #endregion

        #region Properties

        public BaseViewModel SettingsContentViewModel
        {
            get { return GetPropertyValue<BaseViewModel>(); }
            set { SetPropertyValue(value); }
        }

        #endregion

        #region Constructors

        public SettingsWindowViewModel(string settingName = null) : base(new SettingsWindow())
        {
            _settingsViewModel = new SettingsViewModel(this, settingName);
            _addLocationViewModel = new AddInstanceLocationViewModel();
            SettingsContentViewModel = _settingsViewModel;

            Subscribe();
        }

        #endregion

        #region Event subscriptions

        private void Subscribe()
        {
            SubscribeForMessage<BaseViewModel>(MessagingTokens.ChangeSettingsContentView, OnChangeSettingsContentView);
            SubscribeForMessage<Type>(MessagingTokens.ChangeSettingsContentView, OnChangeSettingsContentView);
        }

        #endregion

        #region Messaging Events

        private void OnChangeSettingsContentView(BaseViewModel viewModel)
        {
            SettingsContentViewModel = viewModel;
        }

        private void OnChangeSettingsContentView(Type type)
        {
            if (type == typeof(SettingsViewModel))
            {
                if (_settingsViewModel == null)
                {
                    _settingsViewModel = new SettingsViewModel(this);
                }
                SettingsContentViewModel = _settingsViewModel;
            }
            else if (type == typeof(AddInstanceLocationViewModel))
            {
                if (_addLocationViewModel == null)
                {
                    _addLocationViewModel = new AddInstanceLocationViewModel();
                }
                SettingsContentViewModel = _addLocationViewModel;
            }
        }

        #endregion
    }
}
