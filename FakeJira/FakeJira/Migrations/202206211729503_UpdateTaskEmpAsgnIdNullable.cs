namespace FakeJira.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTaskEmpAsgnIdNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "EmployeeAsgnId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "EmployeeAsgnId", c => c.Int(nullable: false));
        }
    }
}
