using System;
using GhostLauncher.Client.Entities.Instances;

namespace GhostLauncher.Client.Events
{
    public class CreateInstanceArgs : EventArgs
    {
        public Instance Instance { get; set; }
    }
}
