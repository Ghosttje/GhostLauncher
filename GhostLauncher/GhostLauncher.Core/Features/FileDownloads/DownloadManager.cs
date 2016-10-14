using System.Collections.Generic;
using GhostLauncher.Core.Elements;
using GhostLauncher.Core.Features.Interfaces;
using GhostLauncher.Entities.Features.FileDownloads;

namespace GhostLauncher.Core.Features.FileDownloads
{
    public class DownloadManager : IDownloadManager
    {
        #region Private Properties

        private readonly IConfigurationService _configurationService;
        private int _threadCount;
        private bool _isStarted;

        #endregion

        public BlockingQueue<FileDownload> Files { get; set; }
        public readonly List<DownloadThread> DownloadThreads = new List<DownloadThread>();
        
        public DownloadManager(IConfigurationService configurationService, int threadCount = 1)
        {
            _configurationService = configurationService;
            _threadCount = threadCount;
            Files = new BlockingQueue<FileDownload>();
        }

        public int ThreadCount
        {
            get { return _threadCount; }
            set
            {
                if (_isStarted)
                {
                    if (value == 0)
                    {
                        Stop();
                    }
                    else if (value > _threadCount)
                    {
                        var difference = _threadCount - value;

                        for (var i = 0; i < difference; i++)
                        {
                            DownloadThreads.Add(new DownloadThread(_configurationService, this));
                        }
                    }
                    else if (value < _threadCount)
                    {
                        for (var i = _threadCount - 1; i >= value; i--)
                        {
                            DownloadThreads[i].IsRunning = false;
                        }
                    }
                }
                _threadCount = value;
            }
        }

        public void Start()
        {
            for (var i = 0; i < _threadCount; i++)
            {
                DownloadThreads.Add(new DownloadThread(_configurationService, this));
            }
            _isStarted = true;
        }

        public void Stop()
        {
            foreach (var thread in DownloadThreads)
            {
                thread.IsRunning = false;
                Files.Close();
            }
        }
    }
}