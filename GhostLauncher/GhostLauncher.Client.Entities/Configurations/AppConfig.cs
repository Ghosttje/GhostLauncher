using System;
using System.Collections.Generic;

namespace GhostLauncher.Client.Entities.Configurations
{
    public class AppConfig
    {
        private string _instanceConfigFile = "instances.xml";
        private string _minecraftFolderPath = "minecraft/";
        private string _cache = "cache/";
        private bool _isFirstTime = true;
        private List<InstanceFolderConfig> _instanceFolders = new List<InstanceFolderConfig>();

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

        public List<InstanceFolderConfig> InstanceFolders
        {
            get { return _instanceFolders; }
            set { _instanceFolders = value; }
        }

        #endregion
    }
}
