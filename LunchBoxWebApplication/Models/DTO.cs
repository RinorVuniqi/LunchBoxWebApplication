using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LunchBoxWebApplication.Models
{
    public class CategoryDTO
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }

    public class SubcategoryDTO
    {
        public Guid SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public string ImageUrl { get; set; }
    }

    public class ProductDTO
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public bool ProductOfTheWeek { get; set; }
        public string ProductDescription { get; set; }
        public string ProductNote { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductPersonName { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Ingredients { get; set; }
        public string IngredientsBlobbed { get; set; } //serialized Ingredients
    }
}