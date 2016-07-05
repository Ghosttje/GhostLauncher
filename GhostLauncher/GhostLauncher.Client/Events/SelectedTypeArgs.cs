using System;
using GhostLauncher.Client.Entities.Enums;

namespace GhostLauncher.Client.Events
{
    public class SelectedTypeArgs : EventArgs
    {
        public InstanceType InstanceType { get; set; }
    }
}
