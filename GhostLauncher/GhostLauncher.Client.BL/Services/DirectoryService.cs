using System.IO;
using GhostLauncher.Client.BL.Properties;

namespace GhostLauncher.Client.BL.Services
{
    public static class DirectoryService
    {
        public static string GetConfigDirectory()
        {
            return Settings.Default.ConfigDirectory;
        }

        public static string GetFullConfigUrl(string file)
        {
            return DirectoryService.GetConfigDirectory() + "/" + file;
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
