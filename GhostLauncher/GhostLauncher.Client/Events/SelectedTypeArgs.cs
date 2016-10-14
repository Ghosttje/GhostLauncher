using System;
using GhostLauncher.Entities.Enums;

namespace GhostLauncher.Client.Events
{
    public class SelectedTypeArgs : EventArgs
    {
        public InstanceTypes InstanceType { get; set; }
    }
}
