using System.Data.Entity;
using GhostLauncher.Client.Database.Migrations;
using GhostLauncher.Entities;
using Repository.Pattern.Ef6;

namespace GhostLauncher.Client.Database
{
    public class ClientContext : DataContext
    {
        static ClientContext()
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<ClientContext, Configuration>());
        }

        public ClientContext()
            : base("GhostLauncherClientModel")
        {
            
        }

        public ClientContext(string connectionString) : base(connectionString)
        {
            
        }

        public virtual DbSet<MinecraftVersion> MinecraftVersions { get; set; }
    }
}
