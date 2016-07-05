using System.Xml.Serialization;
using GhostLauncher.Client.Entities.Enums;
using GhostLauncher.Client.Entities.Locations;
using GhostLauncher.Core;
using GhostLauncher.Entities;

namespace GhostLauncher.Client.Entities.Instances
{
    [XmlInclude(typeof(LocalInstance))]
    [XmlInclude(typeof(RemoteInstance))]
    public class Instance : NotifyPropertyChanged
    {
        public string Name
        {
            get { return GetPropertyValue<string>(); }
            set { SetPropertyValue(value); }
        }

        public string Icon
        {
            get { return GetPropertyValue<string>(); }
            set { SetPropertyValue(value); }
        }

        public MinecraftVersion Version
        {
            get { return GetPropertyValue<MinecraftVersion>(); }
            set { SetPropertyValue(value); }
        }
        public InstanceType InstanceType
        {
            get { return GetPropertyValue<InstanceType>(); }
            set { SetPropertyValue(value); }
        }

        [XmlIgnore]
        public InstanceLocation InstanceLocation
        {
            get { return GetPropertyValue<InstanceLocation>(); }
            set { SetPropertyValue(value); }
        }

        #region Constructors

        public Instance()
        {
            Icon = "InstanceLogo";
        }

        #endregion
    }
}
