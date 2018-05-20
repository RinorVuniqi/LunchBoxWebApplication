namespace LunchBoxWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Guid(nullable: false),
                        CategoryName = c.String(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Guid(nullable: false),
                        OrderTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderTotalProductCount = c.Int(nullable: false),
                        DeliverySelected = c.Boolean(nullable: false),
                        OrderCompanyName = c.String(maxLength: 50),
                        OrderTime = c.DateTime(nullable: false),
                        OrderPayment_PaymentId = c.Guid(nullable: false),
                        OrderUser_UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Payments", t => t.OrderPayment_PaymentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.OrderUser_UserId, cascadeDelete: true)
                .Index(t => t.OrderPayment_PaymentId)
                .Index(t => t.OrderUser_UserId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Guid(nullable: false),
                        PaymentName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PaymentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(maxLength: 50),
                        UserEmail = c.String(maxLength: 50),
                        UserPassword = c.String(maxLength: 50),
                        UserFirstName = c.String(maxLength: 50),
                        UserLastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.OrderedProducts",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        ProductName = c.String(nullable: false),
                        ProductOfTheWeek = c.Boolean(nullable: false),
                        ProductDescription = c.String(maxLength: 100),
                        ProductNote = c.String(maxLength: 500),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductQuantity = c.Int(nullable: false),
                        ProductPersonName = c.String(maxLength: 100),
                        ImageUrl = c.String(),
                        IngredientsBlobbed = c.String(),
                        SubcategoryId = c.Guid(nullable: false),
                        Order_OrderId = c.Guid(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Subcategories", t => t.SubcategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .Index(t => t.SubcategoryId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        SubcategoryId = c.Guid(nullable: false),
                        SubcategoryName = c.String(nullable: false),
                        ImageUrl = c.String(),
                        CategoryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SubcategoryId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        ProductName = c.String(nullable: false),
                        ProductOfTheWeek = c.Boolean(nullable: false),
                        ProductDescription = c.String(maxLength: 100),
                        ProductNote = c.String(maxLength: 500),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductQuantity = c.Int(nullable: false),
                        ProductPersonName = c.String(maxLength: 100),
                        ImageUrl = c.String(),
                        IngredientsBlobbed = c.String(),
                        SubcategoryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Subcategories", t => t.SubcategoryId, cascadeDelete: true)
                .Index(t => t.SubcategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SubcategoryId", "dbo.Subcategories");
            DropForeignKey("dbo.OrderedProducts", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderedProducts", "SubcategoryId", "dbo.Subcategories");
            DropForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Orders", "OrderUser_UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "OrderPayment_PaymentId", "dbo.Payments");
            DropIndex("dbo.Products", new[] { "SubcategoryId" });
            DropIndex("dbo.Subcategories", new[] { "CategoryId" });
            DropIndex("dbo.OrderedProducts", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderedProducts", new[] { "SubcategoryId" });
            DropIndex("dbo.Orders", new[] { "OrderUser_UserId" });
            DropIndex("dbo.Orders", new[] { "OrderPayment_PaymentId" });
            DropTable("dbo.Products");
            DropTable("dbo.Subcategories");
            DropTable("dbo.OrderedProducts");
            DropTable("dbo.Users");
            DropTable("dbo.Payments");
            DropTable("dbo.Orders");
            DropTable("dbo.Categories");
        }
    }
}
