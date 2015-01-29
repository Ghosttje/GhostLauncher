using System.Collections.Generic;
using System.IO;
using System.Net;
using GhostLauncher.Client.BL.Properties;
using GhostLauncher.Entities;
using Newtonsoft.Json;

namespace GhostLauncher.Client.BL.Services
{
    public class JsonService
    {
        public JsonService()
        {
            DirectoryService.CreateConfigDir();
            if (File.Exists(Settings.Default.VersionsFileName))
            {
                DownloadVersionFile();
            }
        }

        private static void DownloadVersionFile()
        {
            using (var myWebClient = new WebClient())
            {
                myWebClient.DownloadFile(Settings.Default.VersionsDownloadUrl, DirectoryService.GetFullConfigUrl(Settings.Default.VersionsFileName));
            }
        }

        public IEnumerable<MinecraftVersion> ParseMinecraftVersions()
        {
            JsonVersionRoot root;
            using (var r = new StreamReader("config/versions.json"))
            {
                var json = r.ReadToEnd();
                root = JsonConvert.DeserializeObject<JsonVersionRoot>(json);
            }

            return root.Versions;
        }
    }
}
