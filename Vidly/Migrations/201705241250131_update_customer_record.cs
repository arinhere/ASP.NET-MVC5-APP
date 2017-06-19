namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_customer_record : DbMigration
    {
        public override void Up()
        {
            Sql("update Customers set BirthDate=GETDATE() where Id=2");
        }
        
        public override void Down()
        {
        }
    }
}
