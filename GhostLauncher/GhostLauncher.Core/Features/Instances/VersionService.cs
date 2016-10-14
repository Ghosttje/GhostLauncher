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
        #region Properties

        public List<MinecraftVersion> MinecraftVersions { get; set; }

        #endregion

        #region Init

        public void Init()
        {
            Directory.CreateDirectory(Settings.Default.ConfigDirectory);
            if (!File.Exists(Settings.Default.ConfigDirectory + Settings.Default.VersionsFileName))
            {
                DownloadVersionFile();
            }

            LoadVersions();
        }

        #endregion

        #region Get / Set methods

        private string GetVersionUrl()
        {
            return Settings.Default.ConfigDirectory + "/" + Settings.Default.VersionsFileName;
        }

        #endregion

        #region Functionality

        private void DownloadVersionFile()
        {
            using (var myWebClient = new WebClient())
            {
                myWebClient.DownloadFile(new Uri(Settings.Default.VersionsDownloadUrl), GetVersionUrl());
            }
        }

        public void LoadVersions()
        {
            MinecraftVersions = JsonHelper.ReadJson<JsonVersionRoot>(GetVersionUrl()).Versions;
        }

        #endregion
    }
}
