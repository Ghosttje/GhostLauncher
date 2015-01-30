﻿using GhostLauncher.Client.BL.Managers;

namespace GhostLauncher.Client.BL
{
    public class MasterManager
    {
        public ConfigurationManager ConfigurationManager { get; set; }
        public InstanceManager InstanceManager { get; set; }
        public VersionManager VersionManager { get; set; }
        private static MasterManager _singleton;
        
        public static MasterManager GetSingleton
        {
            get { return _singleton ?? (_singleton = new MasterManager()); }
        }

        public MasterManager()
        {
            ConfigurationManager = new ConfigurationManager();
            InstanceManager = new InstanceManager();
            VersionManager = new VersionManager();
        }

        public void StartApp()
        {
            ConfigurationManager.Init();
            InstanceManager.FindInstances();
        }
    }
}