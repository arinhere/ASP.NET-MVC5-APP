namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCustomers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Membership_Id", "dbo.Memberships");
            DropIndex("dbo.Customers", new[] { "Membership_Id" });
            DropColumn("dbo.Customers", "MembershipTypeId");
            RenameColumn(table: "dbo.Customers", name: "Membership_Id", newName: "MembershipTypeId");
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.Memberships", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.Memberships");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Int());
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "Membership_Id");
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "Membership_Id");
            AddForeignKey("dbo.Customers", "Membership_Id", "dbo.Memberships", "Id");
        }
    }
}
