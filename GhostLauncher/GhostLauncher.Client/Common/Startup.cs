using System;
using GhostLauncher.Core.NinjectCore;
using Ninject;

namespace GhostLauncher.Client.Common
{
    public static class Startup
    {
        public static IKernel Kernel;

        public static void Load()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Kernel = BootstrapHelper.LoadNinjectKernel(assemblies);
        }
    }
}
