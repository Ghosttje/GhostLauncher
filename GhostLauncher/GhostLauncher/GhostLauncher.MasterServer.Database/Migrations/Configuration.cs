using System.Data.Entity.Migrations;
using System.Linq;
using GhostLauncher.Entities;
using GhostLauncher.Entities.Enums;

namespace GhostLauncher.MasterServer.Database.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MasterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MasterContext context)
        {
            if (!context.MinecraftVersions.Any())
            {
                var releaseVersions = new[]
                {
                    "1.8", "1.7.10", "1.7.9", "1.7.5", "1.7.4", "1.7.2", "1.6.4", "1.6.2", "1.6.1", "1.5.5", "1.5.1",
                    "1.4.7", "1.4.6", "1.4.5", "1.4.4", "1.4.2", "1.3.2", "1.3.1", "1.2.5", "1.2.4", "1.2.3", "1.2.2",
                    "1.2.1", "1.1", "1.0"
                };

                var snapshotVersions = new[]
                {
                    "1.8.1-pre4", "1.8.1-pre3", "1.8.1-pre2", "1.8.1-pre1"
                };


                foreach (var releaseVersion in releaseVersions)
                {
                    context.MinecraftVersions.AddOrUpdate(new MinecraftVersion()
                    {
                        Version = releaseVersion,
                        Url = MinecraftVersion.CreateUrl(releaseVersion)
                    });
                    context.MinecraftVersions.AddOrUpdate(new MinecraftVersion()
                    {
                        Version = releaseVersion,
                        Url = MinecraftVersion.CreateUrl(releaseVersion),
                        InstanceType = InstanceTypes.Server
                    });
                }

                foreach (var snapshotVersion in snapshotVersions)
                {
                    context.MinecraftVersions.AddOrUpdate(new MinecraftVersion()
                    {
                        Version = snapshotVersion,
                        Url = MinecraftVersion.CreateUrl(snapshotVersion),
                        ReleaseType = ReleaseTypes.Snapshot
                    });
                    context.MinecraftVersions.AddOrUpdate(new MinecraftVersion()
                    {
                        Version = snapshotVersion,
                        Url = MinecraftVersion.CreateUrl(snapshotVersion),
                        InstanceType = InstanceTypes.Server,
                        ReleaseType = ReleaseTypes.Snapshot
                    });
                }
            }

            context.SyncObjectsStatePostCommit();
            context.SaveChanges();
        }
    }
}
