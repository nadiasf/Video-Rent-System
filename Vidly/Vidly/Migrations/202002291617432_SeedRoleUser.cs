namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedRoleUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'84a94001-128e-495f-8588-2fcbce6cb549', N'guest@gmail.com', 0, N'AJheZk+PxCz9jZ70tTFlVUuSTKioPqYqjTQF4iWT9tBGwYt5Xr/nxWbb7amC4xlhKQ==', N'c19f77f5-3fd3-45c3-9359-55dae66d4b6a', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'96739ec9-919c-40c7-b6e3-6f3ddcc418ee', N'admin@vidly.com', 0, N'ALTTcnTW5d+iM8PY0kXbaath8e7X/qddBs9i8x8ZrUQV8HKlLj4i3WdJWcKEGbYPtA==', N'66db03b4-561b-47e6-a85d-7eabd56e8901', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ad56d4c6-e09a-4fd0-b632-b3dc8f938e34', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'96739ec9-919c-40c7-b6e3-6f3ddcc418ee', N'ad56d4c6-e09a-4fd0-b632-b3dc8f938e34')
            ");
        }

        public override void Down()
        {
        }
    }
}
