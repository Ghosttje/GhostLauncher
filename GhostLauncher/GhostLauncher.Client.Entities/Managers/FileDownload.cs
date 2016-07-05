namespace GhostLauncher.Client.Entities.Managers
{
    public struct FileDownload
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public delegate void DownloadCompleted(FileDownload fileDownload);
        public DownloadCompleted DownloadFileCompleted { get; set; }
    }
}
