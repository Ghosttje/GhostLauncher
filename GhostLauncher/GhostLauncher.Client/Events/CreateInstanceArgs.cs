using System;
using GhostLauncher.Entities.Instances;

namespace GhostLauncher.Client.Events
{
    public class CreateInstanceArgs : EventArgs
    {
        public Instance Instance { get; set; }
    }
}
