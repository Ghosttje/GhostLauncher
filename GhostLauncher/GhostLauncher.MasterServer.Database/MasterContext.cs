using System.Data.Entity;
using GhostLauncher.Entities;
using GhostLauncher.MasterServer.Database.Migrations;
using Repository.Pattern.Ef6;

namespace GhostLauncher.MasterServer.Database
{
    public class MasterContext : DataContext
    {
        static MasterContext()
        {
            
        }

        public MasterContext()
            : base("GhostLauncherMasterServerModel")
        {
            
        }

        public MasterContext(string connectionString) : base(connectionString)
        {
            
        }

        public virtual DbSet<MinecraftVersion> MinecraftVersions { get; set; }
    }
}
