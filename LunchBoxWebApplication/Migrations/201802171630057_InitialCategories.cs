namespace LunchBoxWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCategories : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SubcategoryId", "dbo.Subcategories");
            DropForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Subcategories", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "SubcategoryId" });
            DropTable("dbo.Subcategories");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
