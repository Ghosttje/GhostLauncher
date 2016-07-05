using System.Collections.Generic;
using System.IO;
using GhostLauncher.Client.Entities.Instances;
using GhostLauncher.Client.Entities.Managers;

namespace GhostLauncher.Client.BL.Helpers
{
    public static class JarHelper
    {
        private static readonly Dictionary<FileDownload, List<Instance>> DownloadInProgress = new Dictionary<FileDownload, List<Instance>>();

        private static string GetCachePath()
        {
            return Manager.GetSingleton.GetConfig().Cache;
        }

        public static void GetFile(Instance instance)
        {
            Directory.CreateDirectory(GetCachePath());

            var file = GetCachePath() + instance.Version.Version + ".jar";
            if (File.Exists(file)) return;
            var fileStruct = new FileDownload() { Name = instance.Version.Version + ".jar", Url = instance.Version.GetClientUrl(), DownloadFileCompleted = DownloadFileCompleted};
            if (DownloadInProgress.ContainsKey(fileStruct))
            {
                var value = DownloadInProgress[fileStruct];
                value.Add(instance);
                DownloadInProgress[fileStruct] = value;
            }
            else
            {
                var instances = new List<Instance> {instance};
                DownloadInProgress.Add(fileStruct, instances);
                Manager.GetSingleton.DownloadManager.Files.Enqueue(fileStruct);
            }
        }

        private static void DownloadFileCompleted(FileDownload fileDownload)
        {
            var instances = DownloadInProgress[fileDownload];
            foreach (var instance in instances)
            {
                File.Copy(fileDownload.Url, instance.InstanceLocation.Path + Manager.GetSingleton.GetConfig().MinecraftFolderPath + fileDownload.Name + ".jar");
            }
        }
    }
}
