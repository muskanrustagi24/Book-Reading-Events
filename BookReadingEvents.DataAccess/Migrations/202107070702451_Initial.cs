namespace BookReadingEvents.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Guid(nullable: false),
                        TypeOfEvent = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        OtherDetails = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Invitees",
                c => new
                    {
                        InviteeId = c.Int(nullable: false, identity: true),
                        InviteeEmail = c.String(nullable: false),
                        EventId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.InviteeId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invitees", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "UserId", "dbo.Users");
            DropIndex("dbo.Invitees", new[] { "EventId" });
            DropIndex("dbo.Events", new[] { "UserId" });
            DropTable("dbo.Invitees");
            DropTable("dbo.Users");
            DropTable("dbo.Events");
        }
    }
}
