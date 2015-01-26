using GhostLauncher.Client.BL.Services;

namespace GhostLauncher.Client.BL
{
    public static class ConfigurationManager
    {
        private static XmlService _xmlService;

        public static void Init()
        {
            _xmlService = new XmlService();
        }
    }
}
