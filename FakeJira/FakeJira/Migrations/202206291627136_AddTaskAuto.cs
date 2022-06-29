namespace FakeJira.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTaskAuto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "AuthorId");
            AddForeignKey("dbo.Tasks", "AuthorId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "AuthorId", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "AuthorId" });
            DropColumn("dbo.Tasks", "AuthorId");
        }
    }
}
