using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LunchBoxWebApplication.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }
    }
}