using System.Runtime.Serialization;
using GhostLauncher.Core;
using GhostLauncher.Entities.Enums;

namespace GhostLauncher.Entities
{
    [DataContract(Namespace = "")]
    public class MinecraftVersion : GhostLauncherEntity
    {
        private const string BaseUrl = "https://s3.amazonaws.com/Minecraft.Download/versions/";

        private string _version;
        private string _url;
        private InstanceTypes _instanceType = InstanceTypes.Client;
        private ReleaseTypes _releaseType = ReleaseTypes.Release;

        #region Setters / Getters

        [DataMember]
        public string Version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
                OnPropertyChanged();
            }
        }

        [DataMember]
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
                OnPropertyChanged();
            }
        }

        [DataMember]
        public InstanceTypes InstanceType
        {
            get
            {
                return _instanceType;
            }
            set
            {
                _instanceType = value;
                OnPropertyChanged();
            }
        }

        [DataMember]
        public ReleaseTypes ReleaseType
        {
            get
            {
                return _releaseType;
            }
            set
            {
                _releaseType = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public static string CreateUrl(string version)
        {
            return BaseUrl + version + "/" + version + ".jar";
        }
    }
}