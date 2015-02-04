using System.IO;
using System.Xml.Serialization;

namespace GhostLauncher.Client.BL.Helpers
{
    public static class XmlHelper
    {
        public static T ReadConfig<T>(string path)
            where T : class
        {
            var reader = new StreamReader(new FileStream(path, FileMode.Open));
            var xmlWriter = new XmlSerializer(typeof(T));

            var config = (T)xmlWriter.Deserialize(reader);
            reader.Close();

            return config;
        }

        public static void WriteConfig<T>(string path, T config)
            where T : class
        {
            var writer = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate));
            var xmlWriter = new XmlSerializer(typeof(T));

            xmlWriter.Serialize(writer, config);
            writer.Close();
        }
    }
}
