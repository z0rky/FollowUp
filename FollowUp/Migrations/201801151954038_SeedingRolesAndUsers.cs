namespace FollowUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingRolesAndUsers : DbMigration
    {
        public override void Up()
        {
            //password is altijd Manager : Manager1234!, Solver : Solver1234!, ...
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1fb89c06-0681-4504-a5fb-7d1f9edf54dd', N'Administrator')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a9033aeb-a902-4657-8077-197538934f9d', N'Dispatcher')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5d80e606-6488-4b29-9364-04953dd15c72', N'Manager')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c53e289c-76f3-4b76-b402-7eb7c2ff75a1', N'Solver')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'07607b83-ab21-4a5a-ad47-33af6373d529', N'User')

");
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'49ec3199-b41f-436e-865e-6554aa177aa0', N'admin@mail.com', 0, N'AFEyF/LiIRu1drfiQNTBZdzRrHp8J1d7Gpu8zxfqBfSDsH4ELaF3vUmfk39MdR5WaA==', N'354798a9-02a3-401c-8940-f421e917f190', NULL, 0, 0, NULL, 1, 0, N'admin@mail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5a3ca873-a30e-4cb1-b573-a76d73a571f8', N'dispatcher@mail.com', 0, N'AH4/db6REmStwmey3pex+eO+Se31dQtKO+H42xqkH5cG6KvkVvjUek/rGc4G9i8AQw==', N'46151538-5be0-4aff-874e-0c823810bdc9', NULL, 0, 0, NULL, 1, 0, N'dispatcher@mail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9dd6a952-2aaf-4fce-a4b9-93ab08e12128', N'user@mail.com', 0, N'AMvocs2MDhDwjyJcy4w7jbKLA7SZ1CjwL5qRpJ0FOgtPRh4fg8ie/6K6xhHEdo52zw==', N'36956041-06e9-4df1-bf2f-1672e2affb59', NULL, 0, 0, NULL, 1, 0, N'user@mail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b9a46222-8d52-4dea-b53d-4eb1f3b21673', N'manager@mail.com', 0, N'AKkzfiGIo68w1L6lV19RCjCftH8ceOOCZIougkVZXYra+/FNcBMr9sk02/82OH9TBA==', N'23d9152a-745b-4a23-9173-d3ece4152d49', NULL, 0, 0, NULL, 1, 0, N'manager@mail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cf56c395-f57b-4800-931e-91825d5452b4', N'solver@mail.com', 0, N'AEOTLgq2lxjajdfkGeY9EMSmoVsk5VnzjACiK5ekocBOh+HAAwkJR+r5fo4m4brGDg==', N'60e5e593-23c4-4847-b23f-aca9ce36c421', NULL, 0, 0, NULL, 1, 0, N'solver@mail.com')
");
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9dd6a952-2aaf-4fce-a4b9-93ab08e12128', N'07607b83-ab21-4a5a-ad47-33af6373d529')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'49ec3199-b41f-436e-865e-6554aa177aa0', N'1fb89c06-0681-4504-a5fb-7d1f9edf54dd')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b9a46222-8d52-4dea-b53d-4eb1f3b21673', N'5d80e606-6488-4b29-9364-04953dd15c72')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5a3ca873-a30e-4cb1-b573-a76d73a571f8', N'a9033aeb-a902-4657-8077-197538934f9d')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cf56c395-f57b-4800-931e-91825d5452b4', N'c53e289c-76f3-4b76-b402-7eb7c2ff75a1')
");
        }
        
        public override void Down()
        {
        }
    }
}
