using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LunchBoxWebApplication.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        public bool ProductOfTheWeek { get; set; }

        [MaxLength(100)]
        public string ProductDescription { get; set; }

        [MaxLength(500)]
        public string ProductNote { get; set; }

        public decimal ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

        [MaxLength(100)]
        public string ProductPersonName { get; set; }

        public string ImageUrl { get; set; }

        public List<string> Ingredients { get; set; }
        public string IngredientsBlobbed { get; set; } //serialized Ingredients

        //Foreign Key
        public Guid SubcategoryId { get; set; }
        //Navigation property
        public Subcategory Subcategory { get; set; }
    }
}