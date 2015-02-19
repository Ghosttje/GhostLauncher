using GhostLauncher.Client.BL.Managers;
using GhostLauncher.Client.Entities.Configurations;

namespace GhostLauncher.Client.BL
{
    public class Manager
    {
        public ConfigurationManager ConfigurationManager { get; set; }
        public InstanceManager InstanceManager { get; set; }
        public VersionManager VersionManager { get; set; }
        public DownloadManager DownloadManager { get; set; }

        private static Manager _singleton;
        
        public static Manager GetSingleton
        {
            get { return _singleton ?? (_singleton = new Manager()); }
        }

        private Manager()
        {
            ConfigurationManager = new ConfigurationManager();
            InstanceManager = new InstanceManager();
            VersionManager = new VersionManager();
            DownloadManager = new DownloadManager();
        }

        public void StartApp()
        {
            ConfigurationManager.Init();

            if (GetConfig().IsFirstTime)
            {
                GetConfig().InstanceFolders.Add(new InstanceFolder() { Name = "DefaultInstance", IsDefault = true, Path = "instances/"});
                GetConfig().IsFirstTime = false;
                ConfigurationManager.SaveConfig();
            }

            DownloadManager.StartProcessing();

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