using System.Collections.Generic;
using GhostLauncher.Client.BL.Services;
using GhostLauncher.Client.Entities;

namespace GhostLauncher.Client.BL
{
    public class InstanceManager
    {
        private List<ClientInstance> _instances = new List<ClientInstance>(); 

        public void CreateInstance(ClientInstance instance)
        {
            DirectoryService.CreateDir(instance.Path);

            var xmlService = new XmlService();
            xmlService.SaveInstanceConfig(instance);
        }

        public void FindInstances()
        {
            var dirs = DirectoryService.FindDirs(ConfigurationManager.Configuration.InstanceFolderPath);

            foreach (var dir in dirs)
            {
                if (DirectoryService.CheckFile(dir + "/instance.xml"))
                {
                    
                }
            }
        }
    }
}
