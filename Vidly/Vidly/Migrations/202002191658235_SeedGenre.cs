namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres (Id,Name) Values (1,'Action')");
            Sql("Insert Into Genres (Id,Name) Values (2,'Comedy')");
            Sql("Insert Into Genres (Id,Name) Values (3,'Family')");
            Sql("Insert Into Genres (Id,Name) Values (4,'Rommance')");
            Sql("Insert Into Genres (Id,Name) Values (5,'Drama')");
            Sql("Insert Into Genres (Id,Name) Values (6,'Horror')");
            Sql("Insert Into Genres (Id,Name) Values (7,'Sci-fi')");
        }

        public override void Down()
        {
        }
    }
}
