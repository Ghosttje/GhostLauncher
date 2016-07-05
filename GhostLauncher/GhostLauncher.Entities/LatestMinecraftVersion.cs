using System.Runtime.Serialization;

namespace GhostLauncher.Entities
{
    [DataContract]
    public class LatestMinecraftVersion
    {
        [DataMember(Name = "snapshot")]
        public string Snapshot { get; set; }

        [DataMember(Name = "release")]
        public string Release { get; set; }
    }
}
