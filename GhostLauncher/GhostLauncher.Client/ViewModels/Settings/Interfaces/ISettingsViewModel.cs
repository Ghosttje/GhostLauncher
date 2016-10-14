using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostLauncher.Client.ViewModels.Settings.Interfaces
{
    public interface ISettingsViewModel
    {
        bool HasChanges();
        void ApplySettings();
    }
}
