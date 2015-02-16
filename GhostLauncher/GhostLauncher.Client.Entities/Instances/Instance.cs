using System.Xml.Serialization;
using GhostLauncher.Client.Entities.Enums;
using GhostLauncher.Core;
using GhostLauncher.Entities;

namespace GhostLauncher.Client.Entities.Instances
{
    [XmlInclude(typeof(LocalInstance))]
    [XmlInclude(typeof(RemoteInstance))]
    public class Instance : NotifyPropertyChanged
    {
        private string _name;
        private string _icon = "InstanceLogo";
        private string _path;
        public MinecraftVersion Version { get; set; }
        public InstanceType InstanceType { get; set; }
        public bool UsesFolderLocation { get; set; }

        #region Setters/Getters

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged();
            }
        }

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
