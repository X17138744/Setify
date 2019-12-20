namespace SetifyFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Releases : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Releases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateReleased = c.DateTime(),
                        DatePurchased = c.DateTime(nullable: false),
                        Artist_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Artist_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Releases", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Releases", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Releases", new[] { "Customer_Id" });
            DropIndex("dbo.Releases", new[] { "Artist_Id" });
            DropTable("dbo.Releases");
        }
    }
}
