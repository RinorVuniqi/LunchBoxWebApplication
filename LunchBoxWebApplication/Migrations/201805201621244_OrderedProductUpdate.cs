namespace LunchBoxWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderedProductUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderedProducts", "SubcategoryId", "dbo.Subcategories");
            DropIndex("dbo.OrderedProducts", new[] { "SubcategoryId" });
            DropColumn("dbo.OrderedProducts", "ProductOfTheWeek");
            DropColumn("dbo.OrderedProducts", "ProductDescription");
            DropColumn("dbo.OrderedProducts", "IngredientsBlobbed");
            DropColumn("dbo.OrderedProducts", "SubcategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderedProducts", "SubcategoryId", c => c.Guid(nullable: false));
            AddColumn("dbo.OrderedProducts", "IngredientsBlobbed", c => c.String());
            AddColumn("dbo.OrderedProducts", "ProductDescription", c => c.String(maxLength: 100));
            AddColumn("dbo.OrderedProducts", "ProductOfTheWeek", c => c.Boolean(nullable: false));
            CreateIndex("dbo.OrderedProducts", "SubcategoryId");
            AddForeignKey("dbo.OrderedProducts", "SubcategoryId", "dbo.Subcategories", "SubcategoryId", cascadeDelete: true);
        }
    }
}
