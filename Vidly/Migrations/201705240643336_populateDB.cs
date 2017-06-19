namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateDB : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Memberships ON");
            Sql("insert into Memberships(Id,MembershipType,Cost,ValidityInDays,Discount) values(1,'Pay as you go',0,0,0)");
            Sql("insert into Memberships(Id,MembershipType,Cost,ValidityInDays,Discount) values(2,'Monthly',30,30,10)");
            Sql("insert into Memberships(Id,MembershipType,Cost,ValidityInDays,Discount) values(3,'Quarterly',90,90,15)");
            Sql("insert into Memberships(Id,MembershipType,Cost,ValidityInDays,Discount) values(4,'Yearly',300,365,20)");
            Sql("SET IDENTITY_INSERT Memberships OFF");

        }
        
        public override void Down()
        {
        }
    }
}
