using System.IO;
using GhostLauncher.Client.Properties;

namespace GhostLauncher.Client.Services
{
    public static class DirectoryService
    {
        public static string GetConfigDirectory()
        {
            return Settings.Default.ConfigDirectory;
        }

        private static bool CheckConfigDir()
        {
            return Directory.Exists(GetConfigDirectory());
        }

        public static void CreateConfigDir()
        {
            if (!CheckConfigDir())
            {
                Directory.CreateDirectory(GetConfigDirectory());
            }
        }
    }
}
