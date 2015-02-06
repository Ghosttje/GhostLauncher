using System.IO;
using GhostLauncher.Client.BL.Tasks;
using GhostLauncher.Client.Entities.Instances;

namespace GhostLauncher.Client.BL.Helpers
{
    public static class JarHelper
    {
        private static string GetCachePath()
        {
            return MasterManager.GetSingleton.GetConfig().Cache;
        }

        public static void GetFile(Instance instance)
        {
            Directory.CreateDirectory(GetCachePath());

            var file = GetCachePath() + instance.Version.Version + ".jar";
            if (!File.Exists(file))
            {
                var fileDownloader = new FileDownloader(instance.Version.GetClientUrl(), GetCachePath() + instance.Version.Version + ".jar");
                fileDownloader.DownloadFile();
            }
            File.Copy(file, instance.Path);
        }
    }
}
