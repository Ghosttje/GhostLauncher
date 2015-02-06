using System;
using System.ComponentModel;
using System.Net;

namespace GhostLauncher.Client.BL.Tasks
{
    public class FileDownloader
    {
        private readonly Uri _url;
        private readonly string _path;

        public FileDownloader(string url, string fileLocation)
        {
            _url = new Uri(url);
            _path = fileLocation;
        }

        public void DownloadFile()
        {
            using (var myWebClient = new WebClient())
            {
                myWebClient.DownloadFileCompleted += Completed;
                myWebClient.DownloadProgressChanged += ProgressChanged;
                myWebClient.DownloadFileAsync(_url, _path);
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {

        }
    }
}
