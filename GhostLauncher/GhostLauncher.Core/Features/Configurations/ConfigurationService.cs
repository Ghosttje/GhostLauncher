using System.IO;
using GhostLauncher.Client.Entities.Configurations;
using GhostLauncher.Core.Features.Interfaces;
using GhostLauncher.Core.Properties;

namespace GhostLauncher.Core.Features.Configurations
{
    public class ConfigurationService : IConfigurationService
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
            Configuration = XmlConfigHelper.ReadConfig<AppConfig>(GetConfigUrl());
        }

        public void SaveConfig()
        {
            XmlConfigHelper.WriteConfig(GetConfigUrl(), Configuration);
        }
    }
}