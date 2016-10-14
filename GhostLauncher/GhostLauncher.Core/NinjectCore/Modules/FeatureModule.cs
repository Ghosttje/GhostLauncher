using GhostLauncher.Core.Features.Configurations;
using GhostLauncher.Core.Features.FileDownloads;
using GhostLauncher.Core.Features.Instances;
using GhostLauncher.Core.Features.Interfaces;
using Ninject.Modules;

namespace GhostLauncher.Core.NinjectCore.Modules
{
    public class FeatureModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfigurationService>().To<ConfigurationService>().InSingletonScope();
            Bind<IInstanceManager>().To<InstanceManager>().InSingletonScope();
            Bind<IVersionService>().To<VersionService>().InSingletonScope();
            Bind<IDownloadManager>().To<DownloadManager>().InSingletonScope();
        }
    }
}
