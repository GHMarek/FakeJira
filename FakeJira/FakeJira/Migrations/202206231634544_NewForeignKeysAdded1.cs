namespace FakeJira.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewForeignKeysAdded1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "DepartmentId", c => c.Int());
            AlterColumn("dbo.Users", "BusinessRoleId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "BusinessRoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "DepartmentId", c => c.String());
        }
    }
}
