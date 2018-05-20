using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LunchBoxWebApplication.Models;
using Microsoft.Ajax.Utilities;

namespace LunchBoxWebApplication.Controllers
{
    public class OrdersController : ApiController
    {
        private LunchBoxWebApplicationContext db = new LunchBoxWebApplicationContext();

        // GET: api/Orders
        public IQueryable<OrderDTO> GetOrders()
        {
            var orders = from o in db.Orders
                select new OrderDTO()
                {
                    OrderId = o.OrderId,
                    Products = o.Products,
                    DeliverySelected = o.DeliverySelected,
                    OrderCompanyName = o.OrderCompanyName,
                    OrderPayment = o.OrderPayment,
                    OrderTotalProductCount = o.OrderTotalProductCount,
                    OrderTime = o.OrderTime,
                    OrderDate = o.OrderDate,
                    OrderTotalPrice = o.OrderTotalPrice,
                    OrderUser = o.OrderUser
                };

            return orders;
        }

        // GET: api/Orders/5
        [ResponseType(typeof(OrderDTO))]
        public async Task<IHttpActionResult> GetOrder(Guid id)
        {
            var order = await db.Orders.Select(o => new OrderDTO()
            {
                OrderId = o.OrderId,
                Products = o.Products,
                DeliverySelected = o.DeliverySelected,
                OrderCompanyName = o.OrderCompanyName,
                OrderPayment = o.OrderPayment,
                OrderTotalProductCount = o.OrderTotalProductCount,
                OrderTotalPrice = o.OrderTotalPrice
            }).FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrder(Guid id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.OrderId)
            {
                return BadRequest();
            }

            db.Entry(order).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Orders
        [ResponseType(typeof(OrderDTO))]
        public async Task<IHttpActionResult> PostOrder(OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<OrderedProduct> products = new List<OrderedProduct>();

            foreach (var prod in orderDTO.Products)
            {
                products.Add(new OrderedProduct()
                {
                    ProductId = prod.ProductId,
                    ProductName = prod.ProductName,
                    ProductNote = prod.ProductNote,
                    ProductPersonName = prod.ProductPersonName,
                    ProductQuantity = prod.ProductQuantity,
                    ProductPrice = prod.ProductPrice,
                    ImageUrl = prod.ImageUrl
                });
            }

            var order = new Order()
            {
                OrderId = orderDTO.OrderId,
                OrderUser = db.Users.FirstOrDefault(u => u.UserId == orderDTO.OrderUser.UserId),
                Products = products,
                OrderPayment = db.Payments.FirstOrDefault(o => o.PaymentId == orderDTO.OrderPayment.PaymentId),
                DeliverySelected = orderDTO.DeliverySelected,
                OrderCompanyName = orderDTO.OrderCompanyName,
                OrderDate = DateTime.Now.ToLongDateString(),
                OrderTime = DateTime.Now.ToLongTimeString(),
                OrderTotalProductCount = orderDTO.OrderTotalProductCount,
                OrderTotalPrice = orderDTO.OrderTotalPrice
            };

            db.Orders.Add(order);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (OrderExists(order.OrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(order);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> DeleteOrder(Guid id)
        {
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            await db.SaveChangesAsync();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(Guid id)
        {
            return db.Orders.Count(e => e.OrderId == id) > 0;
        }
    }
}