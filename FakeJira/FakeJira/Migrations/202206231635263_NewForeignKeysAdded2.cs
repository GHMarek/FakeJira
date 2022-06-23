namespace FakeJira.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewForeignKeysAdded2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Users", "DepartmentId");
            CreateIndex("dbo.Users", "BusinessRoleId");
            AddForeignKey("dbo.Users", "BusinessRoleId", "dbo.BusinessRoles", "Id");
            AddForeignKey("dbo.Users", "DepartmentId", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Users", "BusinessRoleId", "dbo.BusinessRoles");
            DropIndex("dbo.Users", new[] { "BusinessRoleId" });
            DropIndex("dbo.Users", new[] { "DepartmentId" });
        }
    }
}
