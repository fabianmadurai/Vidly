namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedMembershipTypeNames : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET Name = 'PAY AS YOU GO' WHERE Id = 1");
            Sql("Update MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
            Sql("Update MembershipTypes SET Name = 'Quarterly' WHERE Id = 3");
            Sql("Update MembershipTypes SET Name = 'Yearly' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
