using System.Collections.Generic;
using System.Xml.Serialization;
using GhostLauncher.Client.Entities.Instances;
using GhostLauncher.Core;

namespace GhostLauncher.Client.Entities.Configurations
{
    public class InstanceFolder : NotifyPropertyChanged
    {
        private string _name;
        public string Path { get; set; }

        private List<Instance> _instances = new List<Instance>();

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        [XmlIgnore]
        public List<Instance> Instances
        {
            get { return _instances; }
            set { _instances = value; }
        }
    }
}
