using System.Collections.Generic;
using System.IO;
using GhostLauncher.Core.Features.Interfaces;
using GhostLauncher.Entities.Features.FileDownloads;
using GhostLauncher.Entities.Instances;

namespace GhostLauncher.Core.Features.FileDownloads
{
    public class JarDownloadHelper
    {
        #region Private Properties

        private readonly IConfigurationService _configurationService;
        private readonly IDownloadManager _downloadManager;
        private readonly Dictionary<FileDownload, List<Instance>> DownloadInProgress = new Dictionary<FileDownload, List<Instance>>();

        #endregion

        #region Constructors

        public JarDownloadHelper(IConfigurationService configurationService, DownloadManager downloadManager)
        {
            _configurationService = configurationService;
            _downloadManager = downloadManager;
        }

        #endregion

        #region Get / Set methods

        private string GetCachePath()
        {
            return _configurationService.Configuration.Cache;
        }

        #endregion

        #region Functionality

        public void GetFile(Instance instance)
        {
            Directory.CreateDirectory(GetCachePath());

            var file = GetCachePath() + instance.Version.Version + ".jar";
            if (File.Exists(file)) return;
            var fileStruct = new FileDownload() { Name = instance.Version.Version + ".jar", Url = instance.Version.GetClientUrl(), DownloadFileCompleted = DownloadFileCompleted };
            if (DownloadInProgress.ContainsKey(fileStruct))
            {
                var value = DownloadInProgress[fileStruct];
                value.Add(instance);
                DownloadInProgress[fileStruct] = value;
            }
            else
            {
                var instances = new List<Instance> { instance };
                DownloadInProgress.Add(fileStruct, instances);
                _downloadManager.Files.Enqueue(fileStruct);
            }
        }

        private void DownloadFileCompleted(FileDownload fileDownload)
        {
            var instances = DownloadInProgress[fileDownload];
            foreach (var instance in instances)
            {
                File.Copy(fileDownload.Url, instance.InstanceLocation.Path + _configurationService.Configuration.MinecraftFolderPath + fileDownload.Name + ".jar");
            }
        }

        #endregion
    }
}
