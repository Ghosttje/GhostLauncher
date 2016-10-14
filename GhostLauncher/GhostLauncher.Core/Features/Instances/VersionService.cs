using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using GhostLauncher.Core.Features.Interfaces;
using GhostLauncher.Core.Properties;
using GhostLauncher.Entities;

namespace GhostLauncher.Core.Features.Instances
{
    public class VersionService : IVersionService
    {
        public List<MinecraftVersion> MinecraftVersions { get; set; }

        private string GetVersionUrl()
        {
            return Settings.Default.ConfigDirectory + "/" + Settings.Default.VersionsFileName;
        }

        private void DownloadVersionFile()
        {
            using (var myWebClient = new WebClient())
            {
                myWebClient.DownloadFile(new Uri(Settings.Default.VersionsDownloadUrl), GetVersionUrl());
            }
        }

        public void Init()
        {
            Directory.CreateDirectory(Settings.Default.ConfigDirectory);
            if (!File.Exists(Settings.Default.ConfigDirectory + Settings.Default.VersionsFileName))
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
