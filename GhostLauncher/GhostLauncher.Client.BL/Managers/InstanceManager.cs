using System;
using System.Collections.Generic;
using System.IO;
using GhostLauncher.Client.BL.Helpers;
using GhostLauncher.Client.BL.Properties;
using GhostLauncher.Client.Entities.MinecraftInstances;

namespace GhostLauncher.Client.BL.Managers
{
    public class InstanceManager
    {
        private readonly List<LocalInstance> _instances = new List<LocalInstance>();

        #region Setters / Getters

        public List<LocalInstance> Instances
        {
            get { return _instances; }
        }

        #endregion

        private static string GetInstanceFolder()
        {
            return MasterManager.GetSingleton.ConfigurationManager.Configuration.InstanceFolderPath;
        }

        public void AddInstance(LocalInstance instance)
        {
            var path = String.IsNullOrEmpty(instance.Path) ? GetInstanceFolder() + instance.Name + "/" : instance.Path;

            Directory.CreateDirectory(path);
            if (!File.Exists(path + Settings.Default.InstanceFileName))
            {
                XmlHelper.WriteConfig(path + Settings.Default.InstanceFileName, instance);
                

                _instances.Add(instance);
            }
            else
            {
                Console.WriteLine("Er bestaat al een instance in deze folder.");
            }
        }

        public void AddInstance(RemoteInstance instance)
        {

        }

        public void DeleteInstance(LocalInstance instance)
        {
            var path = String.IsNullOrEmpty(instance.Path) ? GetInstanceFolder() + instance.Name + "/" : instance.Path;
            Directory.Delete(path, true);
            _instances.Remove(instance);
        }

        public void DeleteInstance(RemoteInstance instance)
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
                    var xmlFile = dir + "/" + Settings.Default.InstanceFileName;
                    if (!File.Exists(xmlFile))
                        continue;
                    var instance = XmlHelper.ReadConfig<LocalInstance>(xmlFile);
                    _instances.Add(instance);
                }
            }
        }
    }
}
