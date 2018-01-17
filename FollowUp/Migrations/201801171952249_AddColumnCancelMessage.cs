namespace FollowUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnCancelMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "CancelMessage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Issues", "CancelMessage");
        }
    }
}
