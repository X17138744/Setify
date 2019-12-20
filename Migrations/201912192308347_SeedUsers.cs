namespace SetifyFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7385df69-615a-4275-a6a4-cf48277d1648', N'admin@setify.com', 0, N'AMumw6W6BaPEiNKjAub4dwcjRZeldyGlWg0uLo0S/ZVBH1Oh/+g71rs90AlC7t147Q==', N'aea8b9a9-7d8c-421f-99ee-e6a58e7f0016', NULL, 0, 0, NULL, 1, 0, N'admin@setify.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9242c0d9-e9a9-40cb-89f9-8d5cebfec68e', N'matt@setify.com', 0, N'AN5LrHFFLDSJv4el4iWfIlOTwM0BqKlOpI6H0rLRdhmGLoII3vqjTwYb6HHdXDJt6g==', N'86d4bc60-673d-4e63-8d4e-c70e88d2e835', NULL, 0, 0, NULL, 1, 0, N'matt@setify.com')
            
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7b89a410-a260-48cb-b431-635aaaa3b93b', N'CanManageArtists')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7385df69-615a-4275-a6a4-cf48277d1648', N'7b89a410-a260-48cb-b431-635aaaa3b93b')
            
            ");
        }
        
        public override void Down()
        {
        }
    }
}
