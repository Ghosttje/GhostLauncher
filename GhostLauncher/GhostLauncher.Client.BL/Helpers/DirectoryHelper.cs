using System.Collections.Generic;
using System.IO;
using GhostLauncher.Client.BL.Properties;

namespace GhostLauncher.Client.BL.Helpers
{
    public static class DirectoryHelper
    {
        private static string GetConfigDirectory()
        {
            return Settings.Default.ConfigDirectory;
        }

        public static string GetFullConfigUrl(string file)
        {
            return GetConfigDirectory() + "/" + file;
        }

        public static bool CheckDir(string dir)
        {
            return Directory.Exists(dir);
        }

        public static void CreateDir(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        public static void CreateConfigDir()
        {
            CreateDir(GetConfigDirectory());
        }

        public static IEnumerable<string> FindDirs(string path)
        {
            return Directory.GetDirectories(path);
        }

        public static bool CheckFile(string path)
        {
            return File.Exists(path);
        }
    }
}
