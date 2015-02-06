using GhostLauncher.Client.Entities.Enums;
using GhostLauncher.Core;
using GhostLauncher.Entities;

namespace GhostLauncher.Client.Entities.Instances
{
    public class Instance : NotifyPropertyChanged
    {
        private string _name;
        private string _icon = "InstanceLogo";
        private string _path;
        private MinecraftVersion _version;
        private InstanceType _instanceType;

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

        public MinecraftVersion Version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
            }
        }

        public InstanceType InstanceType
        {
            get
            {
                return _instanceType;
            }
            set
            {
                _instanceType = value;
            }
        }

        #endregion
    }
}
