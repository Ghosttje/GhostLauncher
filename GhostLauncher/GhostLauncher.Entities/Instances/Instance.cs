using System.Xml.Serialization;
using GhostLauncher.Entities.Enums;
using GhostLauncher.Entities.Locations;
using GhostLauncher.WPF.Core;

namespace GhostLauncher.Entities.Instances
{
    //[XmlInclude(typeof(LocalInstance))]
    //[XmlInclude(typeof(RemoteInstance))]
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
        public InstanceTypes InstanceType
        {
            get { return GetPropertyValue<InstanceTypes>(); }
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
