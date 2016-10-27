using GhostLauncher.Client.ViewModels.Settings.Interfaces;
using GhostLauncher.WPF.Core.BaseViewModels;

namespace GhostLauncher.Client.ViewModels.Settings
{
    public class MainSettingsViewModel : BaseViewModel, ISettingsViewModel
    {
        #region Private Properties

        
        #endregion

        #region Properties

        public bool HasChanges { get; set; }

        #endregion

        #region Constructors

        public MainSettingsViewModel()
        {
            
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
    }
}
