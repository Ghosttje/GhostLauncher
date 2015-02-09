using GhostLauncher.Client.BL.Managers;
using GhostLauncher.Client.Entities.Configurations;

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

        private MasterManager()
        {
            ConfigurationManager = new ConfigurationManager();
            InstanceManager = new InstanceManager();
            VersionManager = new VersionManager();
        }

        public void StartApp()
        {
            ConfigurationManager.Init();

            if (GetConfig().IsFirstTime)
            {
                GetConfig().InstanceFolders.Add(new InstanceFolder() { Name = "DefaultInstance", Path = "instances/"});
                GetConfig().IsFirstTime = false;
                ConfigurationManager.SaveConfig();
            }

            foreach (var instanceFolder in GetConfig().InstanceFolders)
            {
                InstanceManager.FindInstances(instanceFolder);
            }
        }

        public AppConfig GetConfig()
        {
            return ConfigurationManager.Configuration;
        }
    }
}