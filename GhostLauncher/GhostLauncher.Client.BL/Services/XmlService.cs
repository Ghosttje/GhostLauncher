using System.IO;
using System.Xml.Serialization;
using GhostLauncher.Client.BL.Properties;
using GhostLauncher.Client.Entities;

namespace GhostLauncher.Client.BL.Services
{
    public class XmlService
    {
        private readonly FileStream _fileStream;

        public XmlService()
        {
            _fileStream = new FileStream(GetFullConfigUrl(Settings.Default.ConfigFileName), FileMode.OpenOrCreate);
            
            DirectoryService.CreateConfigDir();

            if (!File.Exists(GetFullConfigUrl(Settings.Default.ConfigFileName)))
            {
                GenerateDefaultConfig();
            }
        }

        private void GenerateDefaultConfig()
        {
            var config = new ConfigurationFile {InstanceFolderPath = "instances/"};
            
            SaveConfig(config);
        }

        public ConfigurationFile ReadConfig()
        {
            var reader = new StreamReader(_fileStream);
            var xmlWriter = new XmlSerializer(typeof(ConfigurationFile));

            var config = (ConfigurationFile)xmlWriter.Deserialize(reader);
            reader.Close();

            return config;
        }

        public void SaveConfig(ConfigurationFile config)
        {
            var writer = new StreamWriter(_fileStream);
            var xmlWriter = new XmlSerializer(typeof(ConfigurationFile));

            xmlWriter.Serialize(writer, config);
            writer.Close();
        }

        private static string GetFullConfigUrl(string configFile)
        {
            return DirectoryService.GetConfigDirectory() + "/" + configFile;
        }
    }
}
