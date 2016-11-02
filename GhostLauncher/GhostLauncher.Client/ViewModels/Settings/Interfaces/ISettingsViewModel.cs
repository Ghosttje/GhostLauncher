namespace GhostLauncher.Client.ViewModels.Settings.Interfaces
{
    public interface ISettingsViewModel
    {
        bool HasChanges();
        void ApplySettings();
    }
}
