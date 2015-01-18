using System.Data.Entity;
using GhostLauncher.MasterServer;
using GhostLauncher.MasterServer.Database;
using GhostLauncher.MasterServer.Database.Migrations;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace GhostLauncher.MasterServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            System.Data.Entity.Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<MasterContext, Configuration>());

            ConfigureAuth(app);
        }
    }
}
