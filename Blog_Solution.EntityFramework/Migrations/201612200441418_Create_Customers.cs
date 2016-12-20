namespace Blog_Solution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Customers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 60),
                        CustomerRoleId = c.Int(nullable: false),
                        Mobile = c.String(nullable: false, maxLength: 12),
                        Email = c.String(nullable: false, maxLength: 200),
                        PasswordSalt = c.String(nullable: false, maxLength: 20),
                        PasswordFormatId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        LastIpAddress = c.String(maxLength: 16),
                        LastModificationTime = c.DateTime(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Enabled = c.Boolean(nullable: false),
                        RoleName = c.String(nullable: false, maxLength: 20),
                        DisplayOrder = c.Int(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        ParentId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerRoles");
            DropTable("dbo.Customers");
        }
    }
}
