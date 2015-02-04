using GhostLauncher.Client.Views.Windows;

namespace GhostLauncher.Client.Wizards
{
    public class CreateInstanceWizard
    {
        public bool Start()
        {
            var addInstanceWindow = new SelectTypeWindow();
            addInstanceWindow.ShowDialog();

            var createInstanceWindow = new CreateClientWindow();
            createInstanceWindow.ShowDialog();

            return true;
        }
    }
}
