using System;
using System.Collections.Generic;
using GhostLauncher.Client.Entities.Locations;

namespace GhostLauncher.Client.Entities.Configurations
{
    public class AppConfig
    {
        private string _instanceConfigFile = "instance.xml";
        private string _minecraftFolderPath = "minecraft/";
        private string _cache = "cache/";
        private bool _isFirstTime = true;
        private int _downloadThreadCount = 2;
        private List<InstanceLocation> _instanceLocations = new List<InstanceLocation>();

        #region Setters/Getters

        public string InstanceConfigFile
        {
            get { return _instanceConfigFile; }
            set { _instanceConfigFile = value; }
        }

        public string MinecraftFolderPath
        {
            get { return _minecraftFolderPath; }
            set { _minecraftFolderPath = value; }
        }

        public string Cache
        {
            get { return _cache; }
            set { _cache = value; }
        }

        public Boolean IsFirstTime
        {
            get { return _isFirstTime; }
            set { _isFirstTime = value; }
        }

        public int DownloadThreadCount
        {
            get { return _downloadThreadCount; }
            set { _downloadThreadCount = value; }
        }

        public List<InstanceLocation> InstanceLocations
        {
            get { return _instanceLocations; }
            set { _instanceLocations = value; }
        }

        #endregion
    }
}
