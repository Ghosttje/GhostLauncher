using System;
using System.Collections.Generic;
using System.IO;
using GhostLauncher.Client.BL.Helpers;
using GhostLauncher.Client.Entities.Instances;
using GhostLauncher.Client.Entities.Locations;

namespace GhostLauncher.Client.BL.Managers
{
    public class InstanceManager
    {
        private readonly List<Instance> _instances = new List<Instance>();

        public IEnumerable<Instance> Instances
        {
            get { return _instances; }
        }

        private static string GetInstanceConfigFile()
        {
            return Manager.GetSingleton.GetConfig().InstanceConfigFile;
        }

        private static string GetInstancePath(Instance instance)
        {
            return instance.InstanceLocation.Path + instance.Name + "/";
        }

        public void AddInstance(Instance instance)
        {
            Directory.CreateDirectory(GetInstancePath(instance));
            var instanceXml = GetInstancePath(instance) + GetInstanceConfigFile();
            if (!File.Exists(instanceXml))
            {
                XmlHelper.WriteConfig(instanceXml, instance);
                _instances.Add(instance);
            }
            else
            {
                Console.WriteLine("Er bestaat al een instance in deze folder.");
            }
        }

        public void DeleteInstance(Instance instance)
        {
            Directory.Delete(GetInstancePath(instance), true);
            _instances.Remove(instance);
        }

        public static void SetupStructure(Instance instance)
        {
            Directory.CreateDirectory(GetInstancePath(instance) + Manager.GetSingleton.ConfigurationManager.Configuration.MinecraftFolderPath);
        }

        public void FindInstances(InstanceLocation folder)
        {
            if (!Directory.Exists(folder.Path))
            {
                Directory.CreateDirectory(folder.Path);
            }
            else
            {
                if (folder.GetType() == typeof (InstanceFolder))
                {
                    var dirs = Directory.GetDirectories(folder.Path);

                    foreach (var dir in dirs)
                    {
                        var xmlFile = GetInstanceXmlPath(dir);
                        if (!File.Exists(xmlFile))
                            continue;
                        var instance = XmlHelper.ReadConfig<Instance>(xmlFile);
                        instance.InstanceLocation = folder;
                        _instances.Add(instance);
                    }
                }
                else
                {
                    var xmlFile = GetInstanceXmlPath(folder.Path);
                    if (!File.Exists(xmlFile)) return;
                    var instance = XmlHelper.ReadConfig<Instance>(xmlFile);
                    instance.InstanceLocation = folder;
                    _instances.Add(instance);
                }

            }
        }

        private static string GetInstanceXmlPath(string dir)
        {
            return dir + "/" + Manager.GetSingleton.ConfigurationManager.Configuration.InstanceConfigFile;
        }
    }
}