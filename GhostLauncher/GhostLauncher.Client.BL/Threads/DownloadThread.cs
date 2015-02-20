using System.ComponentModel;
using System.Net;
using System.Threading;
using GhostLauncher.Client.BL.Managers;
using GhostLauncher.Client.Entities.Managers;

namespace GhostLauncher.Client.BL.Threads
{
    public class DownloadThread
    {
        private readonly DownloadManager _downloadManager;
        private FileDownload _currentFile;
        private readonly Thread _thread;
        private readonly WebClient _client;

        public bool IsRunning { set; get; }

        public DownloadThread(DownloadManager downloadManager)
        {
            IsRunning = true;
            _downloadManager = downloadManager;
            _thread = new Thread(RunThread);

            _client = new WebClient();
            _client.DownloadProgressChanged += DownloadProgressChanged;
            _client.DownloadFileCompleted += DownloadFileCompleted;

            _thread.Start();
        }

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

        private static string GetCachePath()
        {
            return Manager.GetSingleton.GetConfig().Cache;
        }
    }
}
