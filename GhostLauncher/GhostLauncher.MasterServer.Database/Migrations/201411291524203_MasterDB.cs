namespace GhostLauncher.MasterServer.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MasterDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MinecraftVersions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Version = c.String(),
                        Url = c.String(),
                        IsServer = c.Boolean(nullable: false),
                        IsSnapshot = c.Boolean(nullable: false),
                        IsBeta = c.Boolean(nullable: false),
                        IsAlpha = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MinecraftVersions");
        }
    }
}
