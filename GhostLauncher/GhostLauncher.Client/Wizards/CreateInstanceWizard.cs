using GhostLauncher.Client.Views.Windows;

namespace GhostLauncher.Client.Wizards
{
    public class CreateInstanceWizard
    {
        public void Start()
        {
            var addInstanceWindow = new SelectInstanceWindow();
            addInstanceWindow.ShowDialog();

            var createInstanceWindow = new CreateInstanceWindow();
            createInstanceWindow.ShowDialog();
        }
    }
}
