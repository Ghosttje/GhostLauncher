﻿using System;
using System.Collections.Generic;

namespace GhostLauncher.Client.Entities.Configurations
{
    public class AppConfig
    {
        private string _instanceConfigFile = "instance.xml";
        private string _minecraftFolderPath = "minecraft/";
        private string _cache = "cache/";
        private bool _isFirstTime = true;
        private int _downloadThreadCount = 2;
        private List<InstanceFolder> _instanceFolders = new List<InstanceFolder>();

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

        public List<InstanceFolder> InstanceFolders
        {
            get { return _instanceFolders; }
            set { _instanceFolders = value; }
        }

        #endregion
    }
}
