namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedNameforMeberShiptype : DbMigration
    {
        public override void Up()
        {
            Sql("update MemberShipTypes set Name='Pay as you Go' where Id=1");
            Sql("Update MemberShipTypes SET Name='Monthly' where Id = 2");
            Sql("Update MemberShipTypes SET Name='Quarterly' where Id = 3");
            Sql("Update MemberShipTypes SET Name='Annual' where Id = 4");
        }

        public override void Down()
        {
        }
    }
}
