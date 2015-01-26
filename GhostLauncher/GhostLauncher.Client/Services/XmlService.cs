using System.IO;
using System.Xml;
using GhostLauncher.Client.Properties;

namespace GhostLauncher.Client.Services
{
    public class XmlService
    {
        public XmlService()
        {
            DirectoryService.CreateConfigDir();
            if (File.Exists(Settings.Default.ConfigFileName))
            {
                GenerateDefaultConfig();
            }
        }

        private void GenerateDefaultConfig()
        {
            var fileStream = File.Create(DirectoryService.GetConfigDirectory());
            XmlWriter xmlWriter = new XmlTextWriter(new StreamWriter(fileStream));

            xmlWriter.WriteStartDocumentAsync();
            xmlWriter.WriteStartElement("config");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocumentAsync();
        }
    }
}
