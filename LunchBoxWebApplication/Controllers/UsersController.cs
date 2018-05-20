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
    public class UsersController : ApiController
    {
        private LunchBoxWebApplicationContext db = new LunchBoxWebApplicationContext();

        // GET: api/Users
        public IQueryable<UserDTO> GetUsers()
        {
            var users = from u in db.Users
                        select new UserDTO()
                        {
                            UserId = u.UserId,
                            UserEmail = u.UserEmail,
                            UserPassword = u.UserPassword,
                            UserName = u.UserName,
                            UserFirstName = u.UserFirstName,
                            UserLastName = u.UserLastName
                        };

            return users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(UserDTO))]
        public async Task<IHttpActionResult> GetUser(Guid id)
        {
            var user = await db.Users.Select(u => new UserDTO()
            {
                UserId = u.UserId,
                UserEmail = u.UserEmail,
                UserPassword = u.UserPassword,
                UserName = u.UserName,
                UserFirstName = u.UserFirstName,
                UserLastName = u.UserLastName
            }).FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(Guid id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User()
            {
                UserId = Guid.NewGuid(),
                UserEmail = userDTO.UserEmail,
                UserPassword = userDTO.UserPassword,
                UserName = userDTO.UserName,
                UserFirstName = userDTO.UserFirstName,
                UserLastName = userDTO.UserLastName
            };

            db.Users.Add(user);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(Guid id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(Guid id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }
    }
}