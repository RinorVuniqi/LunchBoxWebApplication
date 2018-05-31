namespace LunchBoxWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderFinished", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderFinished");
        }
    }
}
