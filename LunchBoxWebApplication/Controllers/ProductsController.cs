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
using Newtonsoft.Json;

namespace LunchBoxWebApplication.Controllers
{
    public class ProductsController : ApiController
    {
        private LunchBoxWebApplicationContext db = new LunchBoxWebApplicationContext();

        // GET: api/Products
        public IQueryable<ProductDTO> GetProducts()
        {
            var products = from p in db.Products
                select new ProductDTO()
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    ProductDescription = p.ProductDescription,
                    ProductNote = p.ProductNote,
                    ImageUrl = p.ImageUrl,
                    IngredientsBlobbed = p.IngredientsBlobbed,
                    ProductOfTheWeek = p.ProductOfTheWeek,
                    ProductPersonName = p.ProductPersonName,
                    ProductPrice = p.ProductPrice,
                    ProductQuantity = p.ProductQuantity,
                    SubcategoryId = p.SubcategoryId
                };

            return products; 
        }

        // GET: api/Products/5
        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> GetProduct(Guid id)
        {
            var product = db.Products.Include(p => p.Subcategory).FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Ingredients = product.IngredientsBlobbed != null
                ? JsonConvert.DeserializeObject<List<string>>(product.IngredientsBlobbed)
                : null;

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(Guid id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> PostProduct(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Product
            {
                ProductId = productDTO.ProductId,
                ProductName = productDTO.ProductName,
                ProductDescription = productDTO.ProductDescription,
                ProductNote = productDTO.ProductNote,
                ImageUrl = productDTO.ImageUrl,
                IngredientsBlobbed = productDTO.IngredientsBlobbed,
                ProductOfTheWeek = productDTO.ProductOfTheWeek,
                ProductPersonName = productDTO.ProductPersonName,
                ProductPrice = productDTO.ProductPrice,
                ProductQuantity = productDTO.ProductQuantity,
                SubcategoryId = productDTO.SubcategoryId
            };

            db.Products.Add(product);
            await db.SaveChangesAsync();
            return Ok(productDTO);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(Guid id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(Guid id)
        {
            return db.Products.Count(e => e.ProductId == id) > 0;
        }
    }
}