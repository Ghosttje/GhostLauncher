using System.Collections.Generic;
using System.IO;
using System.Net;
using GhostLauncher.Client.BL.Helpers;
using GhostLauncher.Client.BL.Properties;
using GhostLauncher.Entities;

namespace GhostLauncher.Client.BL.Managers
{
    public class VersionManager
    {
        public List<MinecraftVersion> MinecraftVersions { get; set; } 

        private static string GetVersionUrl()
        {
            return Settings.Default.ConfigDirectory + "/" + Settings.Default.VersionsFileName;
        }

        private static void DownloadVersionFile()
        {
            using (var myWebClient = new WebClient())
            {
                myWebClient.DownloadFile(Settings.Default.VersionsDownloadUrl, GetVersionUrl());
            }
        }

        public void Init()
        {
            Directory.CreateDirectory(Settings.Default.ConfigDirectory);
            if (!File.Exists(Settings.Default.VersionsFileName))
            {
                DownloadVersionFile();
            }

            LoadVersions();
        }

        public void LoadVersions()
        {
            MinecraftVersions = JsonHelper.ReadJson<JsonVersionRoot>(GetVersionUrl()).Versions;
        }
    }
}
