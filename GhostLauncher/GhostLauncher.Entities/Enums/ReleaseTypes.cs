using System.Runtime.Serialization;

namespace GhostLauncher.Entities.Enums
{
    public enum ReleaseTypes
    {
        Release,
        Snapshot,
        [EnumMember(Value = "old_beta")]
        Beta,
        [EnumMember(Value = "old_alpha")]
        Alpha
    }
}
