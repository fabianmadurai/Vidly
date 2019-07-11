namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'958db4b2-bd16-453b-916d-7aa30ad3a2dc', N'guest@vidly.com', 0, N'AORI3aG6waj3VqFQeNinaUSM4N1DD9gr8Ta7TPVFKBWc3FK/aQC3kldSvnq7UaNzDA==', N'1cd21bcc-b8d2-44c9-9bc4-973ec4104c9d', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c63b942e-a0f4-49f9-bb26-5dd095fbfd7c', N'admin@vidly.com', 0, N'AFPK1WNOAbsU8qucCr3B1yGjAJclk8Bs9+jCNGPZynm/Fip2jEi0dBlmr16q/BNFnA==', N'ab2306a1-10b0-4bca-bf2d-d861c35349e3', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0880c8c3-30bd-488f-869b-89312681cbb6', N'CanManageCustomers')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c63b942e-a0f4-49f9-bb26-5dd095fbfd7c', N'0880c8c3-30bd-488f-869b-89312681cbb6')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
