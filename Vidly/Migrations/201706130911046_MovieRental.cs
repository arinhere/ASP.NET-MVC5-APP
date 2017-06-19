namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieRental : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieRentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RentalDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(),
                        Customers_Id = c.Int(),
                        Movies_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customers_Id)
                .ForeignKey("dbo.Movies", t => t.Movies_Id)
                .Index(t => t.Customers_Id)
                .Index(t => t.Movies_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieRentals", "Movies_Id", "dbo.Movies");
            DropForeignKey("dbo.MovieRentals", "Customers_Id", "dbo.Customers");
            DropIndex("dbo.MovieRentals", new[] { "Movies_Id" });
            DropIndex("dbo.MovieRentals", new[] { "Customers_Id" });
            DropTable("dbo.MovieRentals");
        }
    }
}
