namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletephno : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "PhNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "PhNo", c => c.String());
        }
    }
}
