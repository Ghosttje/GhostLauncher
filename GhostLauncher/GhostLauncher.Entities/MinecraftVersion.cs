using System;
using System.Runtime.Serialization;
using GhostLauncher.Entities.Enums;
using GhostLauncher.Entities.Properties;
using GhostLauncher.WPF.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GhostLauncher.Entities
{
    [DataContract]
    public class MinecraftVersion : NotifyPropertyChanged
    {
        [DataMember(Name = "id")]
        public string Version
        {
            get { return GetPropertyValue<string>(); }
            set { SetPropertyValue(value); }
        }

        [DataMember(Name = "time")]
        public DateTime Time
        {
            get { return GetPropertyValue<DateTime>(); }
            set { SetPropertyValue(value); }
        }

        [DataMember(Name = "releaseTime")]
        public DateTime ReleaseTime
        {
            get { return GetPropertyValue<DateTime>(); }
            set { SetPropertyValue(value); }
        }

        [DataMember(Name = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ReleaseTypes ReleaseType
        {
            get { return GetPropertyValue<ReleaseTypes>(); }
            set { SetPropertyValue(value); }
        }

        #region Constructor

        public MinecraftVersion()
        {
            ReleaseType = ReleaseTypes.Release;
        }

        #endregion

        public string GetClientUrl()
        {
            return Settings.Default.MinecraftVersionBaseUrl + Version + "/" + Version + ".jar";
        }

        public string GetServerUrl()
        {
            return Settings.Default.MinecraftVersionBaseUrl + Version + "/minecraft_server." + Version + ".jar";
        }
    }
}