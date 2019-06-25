namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedGenres1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Genres) VALUES('Horror')");
            Sql("INSERT INTO Genres(Genres) VALUES('Comedy')");
            Sql("INSERT INTO Genres(Genres) VALUES('Fantasy')");
            Sql("INSERT INTO Genres(Genres) VALUES('Adult')");
        }
        
        public override void Down()
        {
        }
    }
}
