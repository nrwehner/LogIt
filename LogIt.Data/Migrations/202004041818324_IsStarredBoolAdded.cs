namespace LogIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsStarredBoolAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "IsStarred", c => c.Boolean(nullable: false));
            AddColumn("dbo.FoodItem", "IsStarred", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FoodItem", "IsStarred");
            DropColumn("dbo.UserProfile", "IsStarred");
        }
    }
}
