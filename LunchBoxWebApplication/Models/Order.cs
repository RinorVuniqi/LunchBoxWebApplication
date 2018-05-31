using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LunchBoxWebApplication.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        [Required]
        public decimal OrderTotalPrice { get; set; }
        [Required]
        public int OrderTotalProductCount { get; set; }
        [Required]
        public Payment OrderPayment { get; set; }
        [Required]
        public bool DeliverySelected { get; set; }
        [MaxLength(50)]
        public string OrderCompanyName { get; set; }
        [Required]
        public User OrderUser { get; set; }

        public string OrderDate { get; set; }
        public string OrderTime { get; set; }

        public List<OrderedProduct> Products { get; set; }

        public bool OrderFinished { get; set; }
    }
}