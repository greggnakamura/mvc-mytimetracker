namespace MVC_MyTimeTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProject_UpdatingTicket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Slug = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            AddColumn("dbo.Tickets", "ProjectId", c => c.Int());
            CreateIndex("dbo.Tickets", "ProjectId");
            AddForeignKey("dbo.Tickets", "ProjectId", "dbo.Projects", "ProjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Tickets", new[] { "ProjectId" });
            DropColumn("dbo.Tickets", "ProjectId");
            DropTable("dbo.Projects");
        }
    }
}
