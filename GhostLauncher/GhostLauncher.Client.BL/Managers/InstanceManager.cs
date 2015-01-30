using System;
using System.Collections.Generic;
using System.IO;
using GhostLauncher.Client.BL.Helpers;
using GhostLauncher.Client.BL.Properties;
using GhostLauncher.Client.Entities;
using GhostLauncher.Client.Entities.Configurations;

namespace GhostLauncher.Client.BL.Managers
{
    public class InstanceManager
    {
        private List<ClientInstance> _instances = new List<ClientInstance>();

        private string GetInstanceFolder()
        {
            return MasterManager.GetSingleton.ConfigurationManager.Configuration.InstanceFolderPath;
        }

        public void CreateInstance(ClientInstance instance)
        {
            if (!Directory.Exists(instance.Path))
            {
                Directory.CreateDirectory(instance.Path);
            }
            if (File.Exists(instance.Path + Settings.Default.InstanceFileName))
            {
                XmlHelper.WriteConfig(instance.Path + Settings.Default.InstanceFileName, instance);
            }
            else
            {
                Console.WriteLine("Er bestaat al een instance in deze folder.");
            }
        }

        public void FindInstances()
        {
            if (!Directory.Exists(GetInstanceFolder()))
            {
                Directory.CreateDirectory(GetInstanceFolder());
            }
            else
            {
                var dirs = Directory.GetDirectories(GetInstanceFolder());

                foreach (var dir in dirs)
                {
                    if (Directory.Exists(dir + Settings.Default.InstanceFileName))
                    {
                        var instanceConfiguration = XmlHelper.ReadConfig<ClientInstance>(dir + Settings.Default.InstanceFileName);
                    }
                }
            }
        }
    }
}
