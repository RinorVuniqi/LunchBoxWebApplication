using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LunchBoxWebApplication.Models
{
    public class Subcategory
    {
        public Guid SubcategoryId { get; set; }
        [Required]
        public string SubcategoryName { get; set; }

        public string ImageUrl { get; set; }

        //Foreign Key
        public Guid CategoryId { get; set; }
        //Navigation property
        public Category Category { get; set; }
    }
}