namespace FakeJira.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBusinessRoleModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Manager = c.Int(nullable: false),
                        ParentManagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BusinessRoles");
        }
    }
}
