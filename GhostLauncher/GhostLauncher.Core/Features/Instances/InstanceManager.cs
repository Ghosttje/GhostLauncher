using System;
using System.Collections.Generic;
using System.IO;
using GhostLauncher.Core.Features.Configurations;
using GhostLauncher.Core.Features.Interfaces;
using GhostLauncher.Entities.Instances;
using GhostLauncher.Entities.Locations;

namespace GhostLauncher.Core.Features.Instances
{
    public class InstanceManager : IInstanceManager
    {
        #region Private Properties

        private readonly IConfigurationService _configurationService;

        #endregion

        #region Properties

        public List<Instance> Instances { get; set; }

        #endregion

        #region Constructors

        public InstanceManager(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
            Instances = new List<Instance>();
        }

        #endregion

        #region Get / Set methods

        private string GetInstanceConfigFile()
        {
            return _configurationService.Configuration.InstanceConfigFile;
        }

        private string GetInstancePath(Instance instance)
        {
            return instance.InstanceLocation.Path + instance.Name + "/";
        }

        private string GetInstanceXmlPath(string dir)
        {
            return dir + "/" + _configurationService.Configuration.InstanceConfigFile;
        }

        #endregion

        #region Functionality

        public void AddInstance(Instance instance)
        {
            Directory.CreateDirectory(GetInstancePath(instance));
            var instanceXml = GetInstancePath(instance) + GetInstanceConfigFile();
            if (!File.Exists(instanceXml))
            {
                XmlConfigHelper.WriteConfig(instanceXml, instance);
                Instances.Add(instance);
            }
            else
            {
                Console.WriteLine("Er bestaat al een instance in deze folder.");
            }
        }

        public void DeleteInstance(Instance instance)
        {
            Directory.Delete(GetInstancePath(instance), true);
            Instances.Remove(instance);
        }

        public void SetupStructure(Instance instance)
        {
            Directory.CreateDirectory(GetInstancePath(instance) + _configurationService.Configuration.MinecraftFolderPath);
        }

        public void LoadInstances()
        {
            foreach (var instanceLocation in _configurationService.Configuration.InstanceLocations)
            {
                FindInstances(instanceLocation);
            }
        }

        public void FindInstances(InstanceLocation folder)
        {
            if (!Directory.Exists(folder.Path))
            {
                Directory.CreateDirectory(folder.Path);
            }
            else
            {
                if (folder.GetType() == typeof(InstancesFolder))
                {
                    var dirs = Directory.GetDirectories(folder.Path);

                    foreach (var dir in dirs)
                    {
                        var xmlFile = GetInstanceXmlPath(dir);
                        if (!File.Exists(xmlFile))
                            continue;
                        var instance = XmlConfigHelper.ReadConfig<Instance>(xmlFile);
                        instance.InstanceLocation = folder;
                        Instances.Add(instance);
                    }
                }
                else
                {
                    var xmlFile = GetInstanceXmlPath(folder.Path);
                    if (!File.Exists(xmlFile)) return;
                    var instance = XmlConfigHelper.ReadConfig<Instance>(xmlFile);
                    instance.InstanceLocation = folder;
                    Instances.Add(instance);
                }

            }
        }

        #endregion
    }
}