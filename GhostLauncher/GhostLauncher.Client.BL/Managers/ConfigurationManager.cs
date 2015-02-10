using System.IO;
using GhostLauncher.Client.BL.Helpers;
using GhostLauncher.Client.BL.Properties;
using GhostLauncher.Client.Entities.Configurations;

namespace GhostLauncher.Client.BL.Managers
{
    public class ConfigurationManager
    {
        public AppConfig Configuration { get; set; }

        private static string GetConfigUrl()
        {
            return Settings.Default.ConfigDirectory + "/" + Settings.Default.ConfigFileName;
        }

        public void Init()
        {
            Directory.CreateDirectory(Settings.Default.ConfigDirectory);
            if (!File.Exists(GetConfigUrl()))
            {
                Configuration = new AppConfig();

                SaveConfig();
            }
            else
            {
                LoadConfig();
            }
        }

        public void LoadConfig()
        {
            Configuration = XmlHelper.ReadConfig<AppConfig>(GetConfigUrl());
        }

        public void SaveConfig()
        {
            XmlHelper.WriteConfig(GetConfigUrl(), Configuration);
        }
    }
}