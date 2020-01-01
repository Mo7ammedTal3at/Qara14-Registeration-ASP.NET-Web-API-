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
using Qara14.Models;
using Qara14.Models.ViewModels;

namespace Qara14.Controllers
{
    public class QararsController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET: api/Qarars
        public List<QararVM> GetQarars()
        {
            return db.Qarars.Select(q=>new QararVM{Mosalsal = q.Mosalsal,Markaz = q.Markaz,Year = q.Year,Id=q.Id,Name = q.Name,Captin = q.Captin.Name,Soldier = q.Soldier.Name}).ToList();
        }

        //// GET: api/Qarars/5
        //[ResponseType(typeof(Qarar))]
        //public async Task<IHttpActionResult> GetQarar(int id)
        //{
        //    Qarar qarar = await db.Qarars.FindAsync(id);
        //    if (qarar == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(qarar);
        //}

        // PUT: api/Qarars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQarar(int id, Qarar qarar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != qarar.Id)
            {
                return BadRequest();
            }

            db.Entry(qarar).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QararExists(id))
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

        // POST: api/Qarars
        [ResponseType(typeof(Qarar))]
        public async Task<IHttpActionResult> PostQarar(QararAddtionVM qararVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Qarar qarar;
            Qarar qararInDb = db.Qarars.SingleOrDefault(
                q => q.Mosalsal == qararVm.Mosalsal
                && q.Markaz == qararVm.Markaz
                && q.Year == qararVm.Year
            );
            if (qararInDb != null)
            {
                qarar = new Qarar
                {
                    Name = qararInDb.Name,
                    CaptinId = qararVm.CaptinId,
                    SoldierId = qararVm.SoldierId,
                    Mosalsal = qararVm.Mosalsal,
                    Markaz = qararVm.Markaz,
                    Year = qararVm.Year
                };
            }
            else
            {
                qarar = new Qarar
                {
                    Name = qararVm.Name,
                    CaptinId = qararVm.CaptinId,
                    SoldierId = qararVm.SoldierId,
                    Mosalsal = qararVm.Mosalsal,
                    Markaz = qararVm.Markaz,
                    Year = qararVm.Year
                };
            }
            db.Qarars.Add(qarar);
            await db.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { id = qarar.Id }, qarar);
        }

        // DELETE: api/Qarars/5
        [ResponseType(typeof(Qarar))]
        public async Task<IHttpActionResult> DeleteQarar(int id)
        {
            Qarar qarar = await db.Qarars.FindAsync(id);
            if (qarar == null)
            {
                return NotFound();
            }

            db.Qarars.Remove(qarar);
            await db.SaveChangesAsync();

            return Ok(qarar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QararExists(int id)
        {
            return db.Qarars.Count(e => e.Id == id) > 0;
        }
    }
}