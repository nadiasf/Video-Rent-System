namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMemberShipType1 : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into MemberShipTypes (Id,SignUpFee,DurationInMonth,DiscountRate) Values (1,0,0,0)");
            Sql("Insert Into MemberShipTypes (Id,SignUpFee,DurationInMonth,DiscountRate) Values (2,30,1,10)");
            Sql("Insert Into MemberShipTypes (Id,SignUpFee,DurationInMonth,DiscountRate) Values (3,90,3,15)");
            Sql("Insert Into MemberShipTypes (Id,SignUpFee,DurationInMonth,DiscountRate) Values (4,300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
