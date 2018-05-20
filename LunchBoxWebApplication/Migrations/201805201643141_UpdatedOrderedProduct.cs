namespace LunchBoxWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedOrderedProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderedProducts", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.OrderedProducts", new[] { "Order_OrderId" });
            RenameColumn(table: "dbo.OrderedProducts", name: "Order_OrderId", newName: "OrderId");
            AlterColumn("dbo.OrderedProducts", "OrderId", c => c.Guid(nullable: false));
            CreateIndex("dbo.OrderedProducts", "OrderId");
            AddForeignKey("dbo.OrderedProducts", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedProducts", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderedProducts", new[] { "OrderId" });
            AlterColumn("dbo.OrderedProducts", "OrderId", c => c.Guid());
            RenameColumn(table: "dbo.OrderedProducts", name: "OrderId", newName: "Order_OrderId");
            CreateIndex("dbo.OrderedProducts", "Order_OrderId");
            AddForeignKey("dbo.OrderedProducts", "Order_OrderId", "dbo.Orders", "OrderId");
        }
    }
}
