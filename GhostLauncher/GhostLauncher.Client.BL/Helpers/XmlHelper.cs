using System.IO;
using System.Xml.Serialization;
using GhostLauncher.Client.BL.Properties;
using GhostLauncher.Client.BL.Services;
using GhostLauncher.Client.Entities;
using GhostLauncher.Client.Entities.Configurations;

namespace GhostLauncher.Client.BL.Helpers
{
    public class XmlHelper
    {
        public XmlHelper()
        {
            DirectoryService.CreateConfigDir();

            if (!File.Exists(DirectoryService.GetFullConfigUrl(Settings.Default.ConfigFileName)))
            {
                GenerateDefaultConfig();
            }
        }

        private void GenerateDefaultConfig()
        {
            var config = new AppConfiguration {InstanceFolderPath = "instances/"};
            
            SaveConfig(config);
        }

        public AppConfiguration ReadConfig()
        {
            var reader = new StreamReader(new FileStream(DirectoryService.GetFullConfigUrl(Settings.Default.ConfigFileName), FileMode.Open));
            var xmlWriter = new XmlSerializer(typeof(AppConfiguration));

            var config = (AppConfiguration)xmlWriter.Deserialize(reader);
            reader.Close();

            return config;
        }

        public void SaveConfig(AppConfiguration config)
        {
            var writer = new StreamWriter(new FileStream(DirectoryService.GetFullConfigUrl(Settings.Default.ConfigFileName), FileMode.OpenOrCreate));
            var xmlWriter = new XmlSerializer(typeof(AppConfiguration));

            xmlWriter.Serialize(writer, config);
            writer.Close();
        }

        public ClientInstance ReadInstanceConfig(string path)
        {
            var reader = new StreamReader(new FileStream(path, FileMode.OpenOrCreate));
            var xmlWriter = new XmlSerializer(typeof(ClientInstance));

            var config = (ClientInstance)xmlWriter.Deserialize(reader);
            reader.Close();

            return config;
        }

        public void SaveInstanceConfig(ClientInstance config)
        {
            var writer = new StreamWriter(new FileStream(config.Path, FileMode.OpenOrCreate));
            var xmlWriter = new XmlSerializer(typeof(ClientInstance));

            xmlWriter.Serialize(writer, config);
            writer.Close();
        }
    }
}
