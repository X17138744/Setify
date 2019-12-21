namespace SetifyFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvailableToRelease : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "NumberAvailable", c => c.Byte(nullable: false));

            Sql("UPDATE Artists SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "NumberAvailable");
        }
    }
}
