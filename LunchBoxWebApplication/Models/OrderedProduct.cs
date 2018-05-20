using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LunchBoxWebApplication.Models
{
    public class OrderedProduct
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [MaxLength(500)]
        public string ProductNote { get; set; }

        public decimal ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

        [MaxLength(100)]
        public string ProductPersonName { get; set; }

        public string ImageUrl { get; set; }

        //Foreign Key
        public Guid OrderId { get; set; }
    }
}