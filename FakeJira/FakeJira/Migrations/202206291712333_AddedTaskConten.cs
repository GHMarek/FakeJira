namespace FakeJira.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaskConten : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Contents", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Contents");
        }
    }
}
