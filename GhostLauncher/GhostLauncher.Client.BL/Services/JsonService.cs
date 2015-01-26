using System.Collections.Generic;
using System.IO;
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
            
        }

        public IEnumerable<MinecraftVersion> ParseMinecraftVersions()
        {
            JsonVersionRoot root;
            using (StreamReader r = new StreamReader("config/versions.json"))
            {
                var json = r.ReadToEnd();
                root = JsonConvert.DeserializeObject<JsonVersionRoot>(json);
            }

            return root.Versions;
        }
    }
}
