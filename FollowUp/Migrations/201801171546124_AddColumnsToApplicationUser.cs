namespace FollowUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RoleName", c => c.String());
            DropColumn("dbo.AspNetUsers", "RolesName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "RolesName", c => c.String());
            DropColumn("dbo.AspNetUsers", "RoleName");
        }
    }
}
