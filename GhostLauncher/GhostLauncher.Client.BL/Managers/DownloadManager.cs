using System.Collections.Generic;
using GhostLauncher.Client.BL.Elements;
using GhostLauncher.Client.BL.Threads;
using GhostLauncher.Client.Entities.Managers;

namespace GhostLauncher.Client.BL.Managers
{
    public class DownloadManager
    {
        public BlockingQueue<FileDownload> Files { get; set; }
        public readonly List<DownloadThread> DownloadThreads = new List<DownloadThread>();
        private int _threadCount;

        private bool _isStarted;

        public DownloadManager(int threadCount = 1)
        {
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
                            DownloadThreads.Add(new DownloadThread(this));
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
                DownloadThreads.Add(new DownloadThread(this));
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