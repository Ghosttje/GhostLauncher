using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GhostLauncher.Entities
{
    [DataContract]
    public class JsonVersionRoot
    {
        [DataMember(Name = "latest")]
        public LatestMinecraftVersion Latest { get; set; }

        [DataMember(Name = "versions")]
        public List<MinecraftVersion> Versions { get; set; }
    }
}
