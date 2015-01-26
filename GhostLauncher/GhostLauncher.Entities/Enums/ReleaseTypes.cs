using System;
using System.Runtime.Serialization;

namespace GhostLauncher.Entities.Enums
{
    [Flags]
    public enum ReleaseTypes
    {
        Release = 0,
        Snapshot = 1,
        [EnumMember(Value = "old_beta")]
        Beta = 2,
        [EnumMember(Value = "old_alpha")]
        Alpha = 3
    }
}
