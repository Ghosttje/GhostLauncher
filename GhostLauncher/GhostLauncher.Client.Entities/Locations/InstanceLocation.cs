using System.Xml.Serialization;
using GhostLauncher.Core;

namespace GhostLauncher.Client.Entities.Locations
{
    [XmlInclude(typeof(InstanceFolder))]
    [XmlInclude(typeof(InstancePath))]
    public class InstanceLocation: NotifyPropertyChanged
    {
        public string Path { get; set; }
    }
}
