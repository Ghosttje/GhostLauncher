using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GhostLauncher.Client.BL.Helpers;
using GhostLauncher.Client.Entities.Configurations;
using GhostLauncher.Client.Entities.Instances;

namespace GhostLauncher.Client.BL.Managers
{
    public class InstanceManager
    {
        private static string GetInstanceConfigFile()
        {
            return MasterManager.GetSingleton.GetConfig().InstanceConfigFile;
        }

        public void AddInstance(Instance instance)
        {
            Directory.CreateDirectory(instance.Path);
            if (!File.Exists(instance.Path + GetInstanceConfigFile()))
            {
                XmlHelper.WriteConfig(instance.Path + GetInstanceConfigFile(), instance);

                //TODO: Fix instances
                //_instances.Add(instance);
            }
            else
            {
                Console.WriteLine("Er bestaat al een instance in deze folder.");
            }
        }

        public void DeleteInstance(Instance instance)
        {
            Directory.Delete(instance.Path, true);
            //TODO: Fix instances
            //_instances.Remove(instance);
        }

        public void SetupStructure(Instance instance)
        {
            Directory.CreateDirectory(instance.Path + MasterManager.GetSingleton.ConfigurationManager.Configuration.MinecraftFolderPath);
        }

        public void FindInstances(InstanceFolder folder)
        {
            if (!Directory.Exists(folder.Path))
            {
                Directory.CreateDirectory(folder.Path);
            }
            else
            {
                var dirs = Directory.GetDirectories(folder.Path);

                foreach (var dir in dirs)
                {
                    var xmlFile = dir + "/" + MasterManager.GetSingleton.ConfigurationManager.Configuration.InstanceConfigFile;
                    if (!File.Exists(xmlFile))
                        continue;
                    var instance = XmlHelper.ReadConfig<LocalInstance>(xmlFile);
                    //TODO: Fix instances
                    //_instances.Add(instance);
                }
            }
        }

        public IEnumerable<Instance> GetAllInstances()
        {
            var instances = new List<Instance>();

            foreach (var instanceFolder in MasterManager.GetSingleton.GetConfig().InstanceFolders.Where(x => x.Instances.Count != 0))
            {
                instances.AddRange(instanceFolder.Instances);
            }

            return instances;
        }
    }
}