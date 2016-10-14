using System.Collections.Generic;
using Ninject.Modules;

namespace GhostLauncher.Core.NinjectCore.Interfaces
{
    public interface INinjectModuleBootstrapper
    {
        IList<INinjectModule> GetModules();
    }
}
