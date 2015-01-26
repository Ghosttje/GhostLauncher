using System;
using System.Runtime.Serialization;
using GhostLauncher.Core;
using GhostLauncher.Entities.Enums;
using GhostLauncher.Entities.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GhostLauncher.Entities
{
    [DataContract]
    public class MinecraftVersion : NotifyPropertyChanged
    {
        [DataMember(Name = "id")]
        private string _version;
        [DataMember(Name = "time")]
        private DateTime _time;
        [DataMember(Name = "releaseTime")]
        private DateTime _releaseTime;
        [DataMember(Name = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
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

        public DateTime ReleaseTime
        {
            get
            {
                return _releaseTime;
            }
            set
            {
                _releaseTime = value;
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

        public string CreateClientUrl()
        {
            return Settings.Default.MinecraftVersionBaseUrl + _version + "/" + _version + ".jar";
        }

        public string CreateServerUrl()
        {
            return Settings.Default.MinecraftVersionBaseUrl + _version + "/minecraft_server." + _version + ".jar";
        }
    }
}