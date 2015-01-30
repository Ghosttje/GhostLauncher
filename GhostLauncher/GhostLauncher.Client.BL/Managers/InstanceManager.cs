using System.Collections.Generic;
using System.IO;
using GhostLauncher.Client.BL.Helpers;
using GhostLauncher.Client.BL.Properties;
using GhostLauncher.Client.Entities;

namespace GhostLauncher.Client.BL.Managers
{
    public class InstanceManager
    {
        private List<ClientInstance> _instances = new List<ClientInstance>(); 

        public void CreateInstance(ClientInstance instance)
        {
            Directory.CreateDirectory(instance.Path);

            XmlHelper.WriteConfig(instance.Path + Settings.Default.InstanceFileName,instance);
        }

        public void FindInstances()
        {
            var dirs = Directory.GetDirectories(MasterManager.ConfigurationManager.Configuration.InstanceFolderPath);

            foreach (var dir in dirs)
            {
                if (Directory.Exists(dir + Settings.Default.InstanceFileName))
                {
                    
                }
            }
        }
    }
}
