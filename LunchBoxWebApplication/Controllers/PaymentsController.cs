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
    public class PaymentsController : ApiController
    {
        private LunchBoxWebApplicationContext db = new LunchBoxWebApplicationContext();

        // GET: api/Payments
        public IQueryable<PaymentDTO> GetPayments()
        {
            var payments = from p in db.Payments
                           select new PaymentDTO()
                           {
                               PaymentId = p.PaymentId,
                               PaymentName = p.PaymentName
                           };

            return payments;
        }

        // GET: api/Payments/5
        [ResponseType(typeof(PaymentDTO))]
        public async Task<IHttpActionResult> GetPayment(Guid id)
        {
            var payment = db.Payments.FirstOrDefault(p => p.PaymentId == id);

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        // PUT: api/Payments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPayment(Guid id, Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != payment.PaymentId)
            {
                return BadRequest();
            }

            db.Entry(payment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
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

        // POST: api/Payments
        [ResponseType(typeof(PaymentDTO))]
        public async Task<IHttpActionResult> PostPayment(PaymentDTO paymentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payment = new Payment()
            {
                PaymentId = Guid.NewGuid(),
                PaymentName = paymentDTO.PaymentName
            };

            db.Payments.Add(payment);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaymentExists(payment.PaymentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(payment);
        }

        // DELETE: api/Payments/5
        [ResponseType(typeof(Payment))]
        public async Task<IHttpActionResult> DeletePayment(Guid id)
        {
            Payment payment = await db.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            db.Payments.Remove(payment);
            await db.SaveChangesAsync();

            return Ok(payment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentExists(Guid id)
        {
            return db.Payments.Count(e => e.PaymentId == id) > 0;
        }
    }
}