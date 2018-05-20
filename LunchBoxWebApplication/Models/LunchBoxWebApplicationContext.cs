using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LunchBoxWebApplication.Models
{
    public class LunchBoxWebApplicationContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public LunchBoxWebApplicationContext() : base("name=LunchBoxWebApplicationContext")
        {
        }

        public System.Data.Entity.DbSet<LunchBoxWebApplication.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<LunchBoxWebApplication.Models.Subcategory> Subcategories { get; set; }

        public System.Data.Entity.DbSet<LunchBoxWebApplication.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<LunchBoxWebApplication.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<LunchBoxWebApplication.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<LunchBoxWebApplication.Models.Payment> Payments { get; set; }

        public System.Data.Entity.DbSet<LunchBoxWebApplication.Models.OrderedProduct> OrderedProducts { get; set; }
    }
}
