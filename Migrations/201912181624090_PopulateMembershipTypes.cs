namespace SetifyFinal.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateMembershipTypes : DbMigration
    {

        //Empty migration now filled with SQL data and pass statements
        public override void Up()
        {
            //With add tool Resharper can duplicate line using ctrl d
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (1, 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (2, 9.99, 1, 5)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (3, 29.99, 3, 10)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (4, 49.99, 12, 20)");

        }

        public override void Down()
        {
        }
    }
}
