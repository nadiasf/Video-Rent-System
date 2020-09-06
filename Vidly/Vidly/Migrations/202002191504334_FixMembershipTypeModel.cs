namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixMembershipTypeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberShipTypes", "SignUpFee", c => c.Short(nullable: false));
            DropColumn("dbo.MemberShipTypes", "SingUpFee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberShipTypes", "SingUpFee", c => c.Short(nullable: false));
            DropColumn("dbo.MemberShipTypes", "SignUpFee");
        }
    }
}
