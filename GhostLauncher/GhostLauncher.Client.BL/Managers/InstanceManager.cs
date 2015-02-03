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
        private readonly List<ClientInstance> _instances = new List<ClientInstance>();

        private static string GetInstanceFolder()
        {
            return MasterManager.GetSingleton.ConfigurationManager.Configuration.InstanceFolderPath;
        }

        public void CreateInstance(ClientInstance instance, string path = "")
        {
            path = path == String.Empty ? GetInstanceFolder() + instance.Name + "/" : path;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(path + Settings.Default.InstanceFileName))
            {
                XmlHelper.WriteConfig(path + Settings.Default.InstanceFileName, instance);
            }
            else
            {
                Console.WriteLine("Er bestaat al een instance in deze folder.");
            }
        }

        public void CreateInstance(ServerInstance instance, string path = "")
        {
            
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
                    if (!Directory.Exists(dir + Settings.Default.InstanceFileName)) continue;
                    var instance = XmlHelper.ReadConfig<ClientInstance>(dir + Settings.Default.InstanceFileName);
                    _instances.Add(instance);
                }
            }
        }
    }
}
