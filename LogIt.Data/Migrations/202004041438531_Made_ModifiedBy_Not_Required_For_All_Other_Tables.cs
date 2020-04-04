namespace LogIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Made_ModifiedBy_Not_Required_For_All_Other_Tables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FoodDayItem", "ModifiedBy", c => c.String());
            AlterColumn("dbo.FoodDay", "ModifiedBy", c => c.String());
            AlterColumn("dbo.UserProfile", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfile", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.FoodDay", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.FoodDayItem", "ModifiedBy", c => c.String(nullable: false));
        }
    }
}
