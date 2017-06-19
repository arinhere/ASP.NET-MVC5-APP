namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_movie_model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "InStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "InStock");
        }
    }
}
