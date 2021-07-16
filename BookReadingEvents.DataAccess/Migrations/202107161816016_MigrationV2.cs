using System;
using System.Data.Entity.Migrations;

namespace BookReadingEvents.DataAccess.Migrations
{
    public partial class MigrationV2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "UserId", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "UserId");
            AddForeignKey("dbo.Events", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "UserId", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Users", "UserId");
            AddForeignKey("dbo.Events", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
