namespace LogIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fooditem_Made_ModifiedBy_Not_Required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FoodItem", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FoodItem", "ModifiedBy", c => c.String(nullable: false));
        }
    }
}
