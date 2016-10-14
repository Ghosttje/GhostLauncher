using System;
using System.ComponentModel;
using System.Net;

namespace GhostLauncher.Core.Features.FileDownloads
{
    public class FileDownloader
    {
        #region Private Properties

        private readonly Uri _url;
        private readonly string _path;

        #endregion

        #region Constructors

        public FileDownloader(string url, string fileLocation)
        {
            _url = new Uri(url);
            _path = fileLocation;
        }

        #endregion

        #region Functionality

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

        #endregion
    }
}
