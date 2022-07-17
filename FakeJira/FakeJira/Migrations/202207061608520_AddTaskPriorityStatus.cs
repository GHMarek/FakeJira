namespace FakeJira.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTaskPriorityStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskPriorities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaskStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Tasks", "StatusId");
            CreateIndex("dbo.Tasks", "PriorityId");
            AddForeignKey("dbo.Tasks", "PriorityId", "dbo.TaskPriorities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tasks", "StatusId", "dbo.TaskStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "StatusId", "dbo.TaskStatus");
            DropForeignKey("dbo.Tasks", "PriorityId", "dbo.TaskPriorities");
            DropIndex("dbo.Tasks", new[] { "PriorityId" });
            DropIndex("dbo.Tasks", new[] { "StatusId" });
            DropTable("dbo.TaskStatus");
            DropTable("dbo.TaskPriorities");
        }
    }
}
