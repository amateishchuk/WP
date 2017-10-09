namespace WP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Discussion_AddDateTimes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discussions", "QuestionDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Discussions", "ResponseDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Discussions", "ResponseDateTime");
            DropColumn("dbo.Discussions", "QuestionDateTime");
        }
    }
}
