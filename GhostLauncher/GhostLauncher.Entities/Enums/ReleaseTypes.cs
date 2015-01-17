using System;

namespace GhostLauncher.Entities.Enums
{
    [Flags]
    public enum ReleaseTypes
    {
        Alpha = 0,
        Beta = 1,
        Snapshot = 2,
        Release = 3
    }
}
