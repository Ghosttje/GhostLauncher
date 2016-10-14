using System.Collections.Generic;
using GhostLauncher.Entities.Locations;

namespace GhostLauncher.Entities.Configurations
{
    public class AppConfig
    {
        public string InstanceConfigFile { get; set; } = "instance.xml";

        public string MinecraftFolderPath { get; set; } = "minecraft/";

        public string Cache { get; set; } = "cache/";

        public int DownloadThreadCount { get; set; } = 2;

        public List<InstanceLocation> InstanceLocations { get; set; } = new List<InstanceLocation>();
    }
}
