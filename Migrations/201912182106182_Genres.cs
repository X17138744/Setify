namespace SetifyFinal.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Genres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Techno')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Rock')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Electronic')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Dance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Ambient')");
        }

        public override void Down()
        {
        }
    }
}
