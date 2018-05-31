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
        public Guid CategoryId { get; set; }
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
        public Guid SubcategoryId { get; set; }
    }

    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }

    public class OrderDTO
    {
        public Guid OrderId { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public int OrderTotalProductCount { get; set; }
        public Payment OrderPayment { get; set; }
        public bool DeliverySelected { get; set; }
        public string OrderCompanyName { get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
        public bool OrderFinished { get; set; }
        public User OrderUser { get; set; }
        public List<OrderedProduct> Products { get; set; }
    }

    public class PaymentDTO
    {
        public Guid PaymentId { get; set; }
        public string PaymentName { get; set; }
    }
}