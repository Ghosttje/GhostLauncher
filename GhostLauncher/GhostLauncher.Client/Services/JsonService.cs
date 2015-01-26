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
            using (StreamReader r = new StreamReader("config/versions.json"))
            {
                var json = r.ReadToEnd();
                var item = JsonConvert.DeserializeObject<JsonVersionRoot>(json);
            }
            

            return null;
        }

        public static List<T> RequestList<T>(string requestUrl, bool buildUrlFromBase = true)
        {
            return null;
        }
    }
}
