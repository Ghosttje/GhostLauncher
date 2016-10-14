using System;
using System.Collections.Generic;
using GhostLauncher.Entities.Locations;

namespace GhostLauncher.Client.Entities.Configurations
{
    public class AppConfig
    {
        #region Setters/Getters

        public string InstanceConfigFile { get; set; } = "instance.xml";

        public string MinecraftFolderPath { get; set; } = "minecraft/";

        public string Cache { get; set; } = "cache/";

        public bool IsFirstTime { get; set; } = true;

        public int DownloadThreadCount { get; set; } = 2;

        public List<InstanceLocation> InstanceLocations { get; set; } = new List<InstanceLocation>();

        #endregion
    }
}
