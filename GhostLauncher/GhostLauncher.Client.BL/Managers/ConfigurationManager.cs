using System.IO;
using GhostLauncher.Client.BL.Helpers;
using GhostLauncher.Client.BL.Properties;
using GhostLauncher.Client.Entities.Configurations;

namespace GhostLauncher.Client.BL.Managers
{
    public class ConfigurationManager
    {
        public AppConfiguration Configuration { get; set; }

        private static string GetConfigUrl()
        {
            return Settings.Default.ConfigDirectory + "/" + Settings.Default.ConfigFileName;
        }

        public void Init()
        {
            Directory.CreateDirectory(Settings.Default.ConfigDirectory);
            if (!File.Exists(GetConfigUrl()))
            {
                var config = new AppConfiguration { InstanceFolderPath = "instances/" };
                XmlHelper.WriteConfig(GetConfigUrl(), config);
            }

            LoadConfig();
        }

        public void LoadConfig()
        {
            Configuration = XmlHelper.ReadConfig<AppConfiguration>(GetConfigUrl());
        }

        public void WriteConfig()
        {
            XmlHelper.WriteConfig(GetConfigUrl(), Configuration);
        }
    }
}