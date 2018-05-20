using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LunchBoxWebApplication.Models;

namespace LunchBoxWebApplication.Controllers
{
    public class OrderedProductsController : ApiController
    {
        private LunchBoxWebApplicationContext db = new LunchBoxWebApplicationContext();

        // GET: api/OrderedProducts
        public IQueryable<OrderedProduct> GetOrderedProducts()
        {
            return db.OrderedProducts;
        }

        // GET: api/OrderedProducts/5
        [ResponseType(typeof(OrderedProduct))]
        public async Task<IHttpActionResult> GetOrderedProduct(Guid id)
        {
            List<OrderedProduct> orderedProducts = await db.OrderedProducts.Where(p => p.OrderId == id).ToListAsync();
            if (orderedProducts == null)
            {
                return NotFound();
            }

            return Ok(orderedProducts);
        }

        // PUT: api/OrderedProducts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrderedProduct(Guid id, OrderedProduct orderedProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderedProduct.ProductId)
            {
                return BadRequest();
            }

            db.Entry(orderedProduct).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderedProductExists(id))
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

        // POST: api/OrderedProducts
        [ResponseType(typeof(OrderedProduct))]
        public async Task<IHttpActionResult> PostOrderedProduct(OrderedProduct orderedProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderedProducts.Add(orderedProduct);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderedProductExists(orderedProduct.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = orderedProduct.ProductId }, orderedProduct);
        }

        // DELETE: api/OrderedProducts/5
        [ResponseType(typeof(OrderedProduct))]
        public async Task<IHttpActionResult> DeleteOrderedProduct(Guid id)
        {
            OrderedProduct orderedProduct = await db.OrderedProducts.FindAsync(id);
            if (orderedProduct == null)
            {
                return NotFound();
            }

            db.OrderedProducts.Remove(orderedProduct);
            await db.SaveChangesAsync();

            return Ok(orderedProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderedProductExists(Guid id)
        {
            return db.OrderedProducts.Count(e => e.ProductId == id) > 0;
        }
    }
}