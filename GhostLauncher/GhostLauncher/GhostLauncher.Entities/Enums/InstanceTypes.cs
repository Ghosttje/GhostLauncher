using System;
using System.Runtime.Serialization;

namespace GhostLauncher.Entities.Enums
{
    [Serializable]
    [Flags]
    public enum InstanceTypes
    {
        Client = 0,
        Server = 1
    }
}
