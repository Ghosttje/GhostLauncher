using System.Collections.Generic;
using System.Xml.Serialization;
using GhostLauncher.Client.Entities.Instances;

namespace GhostLauncher.Client.Entities.Configurations
{
    public class InstanceFolderConfig
    {
        public string Name { get; set; }
        public string Path { get; set; }

        private List<Instance> _instances = new List<Instance>();

        [XmlIgnore]
        public List<Instance> Instances { get; set; }
    }
}
