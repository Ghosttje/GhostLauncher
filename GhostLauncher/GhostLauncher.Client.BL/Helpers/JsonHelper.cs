using System.IO;
using Newtonsoft.Json;

namespace GhostLauncher.Client.BL.Helpers
{
    public static class JsonHelper
    {
        public static T ReadJson<T>(string path)
            where T : class
        {
            using (var r = new StreamReader(path))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public static void WriteJson<T>(string path, T item)
            where T : class
        {
            using (var w = new StreamWriter(path))
            {
                var json = JsonConvert.SerializeObject(item);
                w.Write(json);
            }
        }
    }
}
