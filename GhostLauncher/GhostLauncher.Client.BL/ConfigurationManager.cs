using GhostLauncher.Client.BL.Services;
using GhostLauncher.Client.Entities;
using GhostLauncher.Client.Entities.Configurations;

namespace GhostLauncher.Client.BL
{
    public static class ConfigurationManager
    {
        private static XmlService _xmlService;
        public static AppConfiguration Configuration { get; set; }

        public static void Init()
        {
            _xmlService = new XmlService();
            LoadConfig();
        }

        public static void LoadConfig()
        {
            Configuration = _xmlService.ReadConfig();
        }

        public static void WriteConfig()
        {
            _xmlService.SaveConfig(Configuration);
        }
    }
}