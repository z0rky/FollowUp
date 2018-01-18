namespace FollowUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnAssignedTo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "AssignedToId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Issues", "AssignedToId");
        }
    }
}
