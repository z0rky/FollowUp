namespace FollowUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IssueDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "StartDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Issues", "StartDateTime");
        }
    }
}
