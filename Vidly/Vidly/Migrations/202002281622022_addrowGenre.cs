namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrowGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres (Id,Name) Values (8,'Cartoon')");

        }

        public override void Down()
        {
        }
    }
}
