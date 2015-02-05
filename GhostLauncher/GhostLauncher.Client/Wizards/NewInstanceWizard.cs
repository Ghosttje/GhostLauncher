using System.Windows;
using GhostLauncher.Client.BL;
using GhostLauncher.Client.Entities.Enums;
using GhostLauncher.Client.Entities.MinecraftInstances;
using GhostLauncher.Client.ViewModels;
using GhostLauncher.Client.Views.Windows;

namespace GhostLauncher.Client.Wizards
{
    public class NewInstanceWizard
    {
        public bool Start(Window owner)
        {
            var selectTypeWindow = new SelectTypeWindow { Owner = owner };
            selectTypeWindow.ShowDialog();

            if (selectTypeWindow.DialogResult.HasValue && selectTypeWindow.DialogResult.Value)
            {
                var selectTypeViewModel = (SelectTypeViewModel)selectTypeWindow.DataContext;

                if (selectTypeViewModel.InstanceType == InstanceType.Remote)
                {

                }
                else
                {
                    var newClientWindow = new NewLocalWindow() { Owner = owner };
                    newClientWindow.ShowDialog();

                    if (newClientWindow.DialogResult.HasValue && newClientWindow.DialogResult.Value)
                    {
                        var newClientViewModel = (NewLocalViewModel)newClientWindow.DataContext;

                        var client = new LocalInstance() { Name = newClientViewModel.Name, Path = newClientViewModel.InstancePath, Version = newClientViewModel.SelectedVersion };
                        MasterManager.GetSingleton.InstanceManager.AddInstance(client);
                        MasterManager.GetSingleton.JarAsyncHelper.GetFile(client.Version);

                        return true;
                    }
                }
            }

            return false;
        }
    }
}
