using System.Windows;
using GhostLauncher.Client.Entities.Enums;
using GhostLauncher.Client.ViewModels;
using GhostLauncher.Client.Views.Windows;

namespace GhostLauncher.Client.Wizards
{
    public class NewInstanceWizard
    {
        public bool Start(Window owner)
        {
            var selectTypeWindow = new SelectTypeWindow {Owner = owner};
            selectTypeWindow.ShowDialog();

            if (selectTypeWindow.DialogResult.HasValue && selectTypeWindow.DialogResult.Value)
            {
                var selectTypeViewModel = (SelectTypeViewModel)selectTypeWindow.DataContext;

                if (selectTypeViewModel.InstanceType == InstanceType.Server)
                {

                }
                else
                {
                    var newInstanceWindow = new NewClientWindow() { Owner = owner };
                    newInstanceWindow.ShowDialog();

                    if (newInstanceWindow.DialogResult.HasValue && newInstanceWindow.DialogResult.Value)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
}
