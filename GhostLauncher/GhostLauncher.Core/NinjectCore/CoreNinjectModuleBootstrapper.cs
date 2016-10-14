using System.Collections.Generic;
using GhostLauncher.Core.NinjectCore.Interfaces;
using GhostLauncher.Core.NinjectCore.Modules;
using Ninject.Modules;

namespace GhostLauncher.Core.NinjectCore
{
    public class CoreNinjectModuleBootstrapper : INinjectModuleBootstrapper
    {
        public IList<INinjectModule> GetModules()
        {
            return new List<INinjectModule>()
            {
                new FeatureModule()
            };
        }
    }
}
