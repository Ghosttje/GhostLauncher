using System.IO;
using GhostLauncher.Core.Features.Interfaces;
using GhostLauncher.Core.Properties;
using GhostLauncher.Entities.Configurations;
using GhostLauncher.Entities.Locations;

namespace GhostLauncher.Core.Features.Configurations
{
    public class ConfigurationService : IConfigurationService
    {
        #region Properties

        public AppConfig Configuration { get; set; }

        #endregion

        #region Init

        public void Init()
        {
            Directory.CreateDirectory(Settings.Default.ConfigDirectory);
            if (!File.Exists(GetConfigUrl()))
            {
                Configuration = new AppConfig();
                Configuration.InstanceLocations.Add(new InstancesFolder { Name = "DefaultInstance", IsDefault = true, Path = "instances\\" });
                SaveConfig();
            }
            else
            {
                LoadConfig();
            }
        }

        #endregion

        #region Get / Set methods

        private static string GetConfigUrl()
        {
            return Settings.Default.ConfigDirectory + "/" + Settings.Default.ConfigFileName;
        }

        #endregion

        #region Functionality

        public void LoadConfig()
        {
            Configuration = XmlConfigHelper.ReadConfig<AppConfig>(GetConfigUrl());
        }

        public void SaveConfig()
        {
            XmlConfigHelper.WriteConfig(GetConfigUrl(), Configuration);
        }

        #endregion
    }
}