namespace FollowUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnCancelMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "CancelMessage", c => c.String());
            AddColumn("dbo.AspNetUsers", "RoleName", c => c.String());
            AddColumn("dbo.AspNetUsers", "ManagerId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Issues", "CancelMessage");
            DropColumn("dbo.AspNetUsers", "RoleName");
            DropColumn("dbo.AspNetUsers", "ManagerId");
        }
    }
}
