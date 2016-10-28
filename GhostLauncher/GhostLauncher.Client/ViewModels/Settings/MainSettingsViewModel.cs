using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using GhostLauncher.Client.Common;
using GhostLauncher.Client.ViewModels.Settings.Interfaces;
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

        public bool HasChanges { get; set; }

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

        bool ISettingsViewModel.HasChanges()
        {
            return false;
        }

        public void ApplySettings()
        {
            
        }

        #endregion

        #region Command Events

        private void OnAddInstanceLocation()
        {
            
        }

        private void OnRemoveInstanceLocation()
        {
            InstanceLocations.Remove(SelectedInstanceLocation);
        }

        #endregion
    }
}
