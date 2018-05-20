namespace LunchBoxWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedOrderDateAndTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDate", c => c.String());
            AlterColumn("dbo.Orders", "OrderTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "OrderTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "OrderDate");
        }
    }
}
