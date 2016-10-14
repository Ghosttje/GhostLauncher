using GhostLauncher.Core.Elements;
using GhostLauncher.Entities.Features.FileDownloads;

namespace GhostLauncher.Core.Features.Interfaces
{
    public interface IDownloadManager
    {
        BlockingQueue<FileDownload> Files { get; set; }
    }
}
