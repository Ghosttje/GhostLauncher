using GhostLauncher.Client.Views.Settings;
using GhostLauncher.WPF.Core.BaseViewModels;

namespace GhostLauncher.Client.ViewModels.Settings
{
    public class SettingsWindowViewModel : BaseWindowViewModel
    {
        #region Properties

        public bool IsRestartRequired
        {
            get { return GetPropertyValue<bool>(); }
            set { SetPropertyValue(value); }
        }

        #endregion

        #region Constructors

        public SettingsWindowViewModel() : base(new SettingsWindow())
        {

        }

        #endregion
    }
}
