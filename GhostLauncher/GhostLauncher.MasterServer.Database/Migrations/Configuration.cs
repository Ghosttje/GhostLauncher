using System.Data.Entity.Migrations;

namespace GhostLauncher.MasterServer.Database.Migrations
{
    public class Configuration : DbMigrationsConfiguration<MasterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MasterContext context)
        {

        }
    }
}
