using System.ComponentModel;
using System.Net;
using System.Threading;
using GhostLauncher.Client.BL.Elements;
using GhostLauncher.Client.Entities.Managers;

namespace GhostLauncher.Client.BL.Managers
{
    public class DownloadManager
    {
        public BlockingCollection<FileDownload> Files { get; set; }

        private FileDownload _currentFile;

        private readonly Thread _thread;
        private readonly WebClient _client;

        private bool _running = true;

        public DownloadManager()
        {
            Files = new BlockingCollection<FileDownload>();
            _thread = new Thread(RunThread);
            _client = new WebClient();
            _client.DownloadProgressChanged += DownloadProgressChanged;
            _client.DownloadFileCompleted += DownloadFileCompleted;
        }

        public void StartProcessing()
        {
            _thread.Start();
        }

        private static string GetCachePath()
        {
            return Manager.GetSingleton.GetConfig().Cache;
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
            while (_running)
            {
                _currentFile = Files.Take();
                _client.DownloadFile(_currentFile.Url, GetCachePath() + _currentFile.Name);
            }
        }
    }
}