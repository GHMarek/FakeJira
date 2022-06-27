namespace FakeJira.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "UserId", c => c.Int());
            CreateIndex("dbo.Tasks", "ProjectId");
            CreateIndex("dbo.Tasks", "UserId");
            AddForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tasks", "UserId", "dbo.Users", "Id");
            DropColumn("dbo.Tasks", "EmployeeAsgnId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "EmployeeAsgnId", c => c.Int());
            DropForeignKey("dbo.Tasks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Tasks", new[] { "UserId" });
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            DropColumn("dbo.Tasks", "UserId");
        }
    }
}
