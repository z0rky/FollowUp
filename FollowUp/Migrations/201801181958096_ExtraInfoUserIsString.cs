namespace FollowUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtraInfoUserIsString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExtraInfoes", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExtraInfoes", "UserId", c => c.Int(nullable: false));
        }
    }
}
