using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using GhostLauncher.Client.BL.Properties;
using GhostLauncher.Entities;

namespace GhostLauncher.Client.BL.Helpers
{
    public class JarHelper
    {
        public JarHelper()
        {
            Directory.CreateDirectory(GetCachePath());
        }

        private static string GetCachePath()
        {
            return Settings.Default.Cache;
        }

        public void GetFile(MinecraftVersion version)
        {
            var file = GetCachePath() + version.Version + ".jar";
            if (!File.Exists(file))
            {
                var fileDownloader = new FileDownloader(version.GetClientUrl(), GetCachePath() + version.Version + ".jar");
                fileDownloader.DownloadFile();
            }
        }
    }
}
