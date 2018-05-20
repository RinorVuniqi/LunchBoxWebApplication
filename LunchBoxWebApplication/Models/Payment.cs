using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LunchBoxWebApplication.Models
{
    public class Payment
    {
        public Guid PaymentId { get; set; }

        [Required, MaxLength(50)]
        public string PaymentName { get; set; }
    }
}