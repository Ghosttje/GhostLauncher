using System.Runtime.Serialization;
using GhostLauncher.Core;
using GhostLauncher.Entities.Enums;

namespace GhostLauncher.Entities
{
    [DataContract]
    public class MinecraftVersion : GhostLauncherEntity
    {
        private const string BaseUrl = "https://s3.amazonaws.com/Minecraft.Download/versions/";

        [DataMember(Name = "version")]
        private string _version;

        [DataMember(Name = "url")]
        private string _url;

        [DataMember(Name = "instanceType")]
        private InstanceTypes _instanceType = InstanceTypes.Client;

        [DataMember(Name = "releaseType")]
        private ReleaseTypes _releaseType = ReleaseTypes.Release;

        #region Setters / Getters

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