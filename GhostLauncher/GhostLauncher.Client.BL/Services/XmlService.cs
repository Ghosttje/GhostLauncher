using System.IO;
using System.Xml.Serialization;
using GhostLauncher.Client.BL.Properties;
using GhostLauncher.Client.Entities;

namespace GhostLauncher.Client.BL.Services
{
    public class XmlService
    {
        public XmlService()
        {
            DirectoryService.CreateConfigDir();
            if (!File.Exists(GetFullConfigUrl(Settings.Default.ConfigFileName)))
            {
                GenerateDefaultConfig();
            }
        }

        private static void GenerateDefaultConfig()
        {
            var config = new Configuration {InstanceFolderPath = "instances/"};

            var file = new StreamWriter(new FileStream(GetFullConfigUrl(Settings.Default.ConfigFileName), FileMode.OpenOrCreate));
            var xmlWriter = new XmlSerializer(typeof(Configuration));

            xmlWriter.Serialize(file, config);
            file.Close();
        }

        private static string GetFullConfigUrl(string configFile)
        {
            return DirectoryService.GetConfigDirectory() + "/" + configFile;
        }
    }
}
