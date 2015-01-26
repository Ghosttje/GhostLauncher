using System.Data.Entity;
using System.Windows;
using GhostLauncher.Client.Database;
using GhostLauncher.Client.Database.Migrations;

namespace GhostLauncher.Client
{
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<ClientContext, Configuration>());
        }
    }
}
