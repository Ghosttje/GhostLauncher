using System.Collections.Generic;
using System.IO;
using GhostLauncher.Entities;
using Newtonsoft.Json;

namespace GhostLauncher.Client.Services
{
    public class JsonService
    {
        private const string BaseUrl = "http://localhost:59555/api/";

        private static string CreateUrl(string direction)
        {
            return BaseUrl + direction;
        }

        public static List<MinecraftVersion> ParseMinecraftVersions()
        {
            JsonVersionRoot root;
            using (StreamReader r = new StreamReader("config/versions.json"))
            {
                var json = r.ReadToEnd();
                root = JsonConvert.DeserializeObject<JsonVersionRoot>(json);
            }

            return root.Versions;
        }

        public static List<T> RequestList<T>(string requestUrl, bool buildUrlFromBase = true)
        {
            return null;
        }
    }
}
