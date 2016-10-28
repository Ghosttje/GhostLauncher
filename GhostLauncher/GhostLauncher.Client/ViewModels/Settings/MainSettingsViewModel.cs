using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using GhostLauncher.Client.Common;
using GhostLauncher.Client.ViewModels.Settings.Interfaces;
using GhostLauncher.Core.Extensions;
using GhostLauncher.Core.Features.Interfaces;
using GhostLauncher.Entities.Locations;
using GhostLauncher.WPF.Core.BaseViewModels;
using Ninject;

namespace GhostLauncher.Client.ViewModels.Settings
{
    public class MainSettingsViewModel : BaseViewModel, ISettingsViewModel
    {
        #region Private Properties

        private readonly IConfigurationService _configurationService;

        #endregion

        #region Commands

        public RelayCommand AddInstanceLocation => GetCommand(OnAddInstanceLocation);
        public RelayCommand RemoveInstanceLocation => GetCommand(OnRemoveInstanceLocation);
        public RelayCommand ChangeDefaultInstanceFolder => GetCommand(OnDefaultInstanceFolderChanged);

        private bool _instanceLocationsChanged;

        #endregion

        #region Properties

        public ObservableCollection<InstanceLocation> InstanceLocations
        {
            get { return GetPropertyValue<ObservableCollection<InstanceLocation>>(); }
            set { SetPropertyValue(value); }
        }

        public InstanceLocation SelectedInstanceLocation
        {
            get { return GetPropertyValue<InstanceLocation>(); }
            set { SetPropertyValue(value); }
        }

        #endregion

        #region Constructors

        public MainSettingsViewModel()
        {
            _configurationService = Startup.Kernel.Get<IConfigurationService>();
            InstanceLocations = new ObservableCollection<InstanceLocation>(_configurationService.Configuration.InstanceLocations);
            SelectedInstanceLocation = InstanceLocations.FirstOrDefault();
        }

        #endregion

        #region Functionality

        public bool HasChanges()
        {
            return _instanceLocationsChanged;
        }

        public void ApplySettings()
        {
            if (_instanceLocationsChanged)
            {
                _configurationService.Configuration.InstanceLocations = InstanceLocations.ToList();
            }
            if (HasChanges())
            {
                _configurationService.SaveConfig();
            }
        }

        #endregion

        #region Command Events

        private void OnAddInstanceLocation()
        {
            _instanceLocationsChanged = true;
        }

        private void OnRemoveInstanceLocation()
        {
            InstanceLocations.Remove(SelectedInstanceLocation);
            _instanceLocationsChanged = true;
        }

        private void OnDefaultInstanceFolderChanged()
        {
            if (SelectedInstanceLocation.GetType() != typeof(InstancesFolder))
            {
                MessageBox.Show("Please select a instance folder instead!");
                return;
            }
            InstanceLocations.SetDefaultFolder((InstancesFolder)SelectedInstanceLocation);
            _instanceLocationsChanged = true;
        }

        #endregion
    }
}
