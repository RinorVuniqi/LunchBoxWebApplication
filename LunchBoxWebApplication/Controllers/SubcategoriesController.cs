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
    public class SubcategoriesController : ApiController
    {
        private LunchBoxWebApplicationContext db = new LunchBoxWebApplicationContext();

        // GET: api/Subcategories
        public IQueryable<SubcategoryDTO> GetSubcategories()
        {
            var subcategories = from s in db.Subcategories
                select new SubcategoryDTO()
                {
                    SubcategoryId = s.SubcategoryId,
                    SubcategoryName = s.SubcategoryName,
                    ImageUrl = s.ImageUrl,
                    CategoryId = s.CategoryId
                };
            return subcategories;
        }

        // GET: api/Subcategories/5
        [ResponseType(typeof(SubcategoryDTO))]
        public async Task<IHttpActionResult> GetSubcategory(Guid id)
        {
            var subcategory = await db.Subcategories.Select(s => new SubcategoryDTO()
            {
                SubcategoryId = s.SubcategoryId,
                SubcategoryName = s.SubcategoryName,
                ImageUrl = s.ImageUrl,
                CategoryId = s.CategoryId

            }).FirstOrDefaultAsync();

            if (subcategory == null)
            {
                return NotFound();
            }

            return Ok(subcategory);
        }

        // PUT: api/Subcategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubcategory(Guid id, Subcategory subcategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subcategory.SubcategoryId)
            {
                return BadRequest();
            }

            db.Entry(subcategory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubcategoryExists(id))
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

        // POST: api/Subcategories
        [ResponseType(typeof(SubcategoryDTO))]
        public async Task<IHttpActionResult> PostSubcategory(SubcategoryDTO subcategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subcategory = new Subcategory()
            {
                SubcategoryId = Guid.NewGuid(),
                SubcategoryName = subcategoryDTO.SubcategoryName,
                ImageUrl = subcategoryDTO.ImageUrl,
                CategoryId = subcategoryDTO.CategoryId
            };

            db.Subcategories.Add(subcategory);
            await db.SaveChangesAsync();
            return Ok(subcategoryDTO);
        }

        // DELETE: api/Subcategories/5
        [ResponseType(typeof(Subcategory))]
        public async Task<IHttpActionResult> DeleteSubcategory(Guid id)
        {
            Subcategory subcategory = await db.Subcategories.FindAsync(id);
            if (subcategory == null)
            {
                return NotFound();
            }

            db.Subcategories.Remove(subcategory);
            await db.SaveChangesAsync();

            return Ok(subcategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubcategoryExists(Guid id)
        {
            return db.Subcategories.Count(e => e.SubcategoryId == id) > 0;
        }
    }
}