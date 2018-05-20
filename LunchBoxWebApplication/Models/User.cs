using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LunchBoxWebApplication.Models
{
    public class User
    {
        public Guid UserId { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string UserEmail { get; set; }

        [MaxLength(50)]
        public string UserPassword { get; set; }

        [MaxLength(50)]
        public string UserFirstName { get; set; }

        [MaxLength(50)]
        public string UserLastName { get; set; }

    }
}