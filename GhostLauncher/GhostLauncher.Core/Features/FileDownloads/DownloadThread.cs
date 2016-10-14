using System.ComponentModel;
using System.Net;
using System.Threading;
using GhostLauncher.Core.Features.Interfaces;
using GhostLauncher.Entities.Features.FileDownloads;

namespace GhostLauncher.Core.Features.FileDownloads
{
    public class DownloadThread
    {
        #region Private Properties

        private readonly IConfigurationService _configurationService;
        private readonly DownloadManager _downloadManager;
        private FileDownload _currentFile;
        private readonly WebClient _client;

        #endregion

        #region Properties

        public bool IsRunning { set; get; }

        #endregion

        #region Constructors

        public DownloadThread(IConfigurationService configurationService, DownloadManager downloadManager)
        {
            _configurationService = configurationService;
            IsRunning = true;
            _downloadManager = downloadManager;
            var thread = new Thread(RunThread);

            _client = new WebClient();
            _client.DownloadProgressChanged += DownloadProgressChanged;
            _client.DownloadFileCompleted += DownloadFileCompleted;

            thread.Start();
        }

        #endregion

        #region Get / Set methods

        private string GetCachePath()
        {
            return _configurationService.Configuration.Cache;
        }

        #endregion

        #region Functionality

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            _currentFile.DownloadFileCompleted(_currentFile);
        }

        private void RunThread()
        {
            while (IsRunning)
            {
                _currentFile = _downloadManager.Files.Dequeue();

                if (!_currentFile.Equals(default(FileDownload)))
                {
                    _client.DownloadFile(_currentFile.Url, GetCachePath() + _currentFile.Name);
                }
            }

        }

#endregion
    }
}
