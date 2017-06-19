namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDBSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                        IsSubscribedToNewsletter = c.Boolean(nullable: false),
                        MembershipTypeId = c.Int(nullable: false),
                        Membership_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Memberships", t => t.Membership_Id)
                .Index(t => t.Membership_Id);
            
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MembershipType = c.String(),
                        Cost = c.Int(nullable: false),
                        ValidityInDays = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Membership_Id", "dbo.Memberships");
            DropIndex("dbo.Customers", new[] { "Membership_Id" });
            DropTable("dbo.Memberships");
            DropTable("dbo.Customers");
        }
    }
}
