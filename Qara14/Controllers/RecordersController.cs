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
    public class RecordersController : ApiController
    {
        private AppDbContext db = new AppDbContext();
        //return all non deleted recorders in the db
        // GET: api/Recorders
        public List<RecorderVM> GetRecorders()
        {
            return db.Recorders.Where(r => !r.IsDeleted).Select(r=>new  RecorderVM{Id=r.Id,Name=r.Name,Daraga=r.Daraga.Text}).ToList();
        }
        //return only non deleted soldiers recorders
        //GET: api/Recorders/Soldiers
        [Route("api/Recorders/Soldiers")]
        public List<RecorderDropDown> GetSoldiers()
        {
            return db.Recorders.Where(r=>r.DaragaId==1&&!r.IsDeleted).Select(r=>new RecorderDropDown{Id=r.Id,Name=r.Name}).ToList();
        }
        //return only non deleted captin recorders
        //GET: api/Recorders/Captins
        [Route("api/Recorders/Captins")]
        public List<RecorderDropDown> GetCaptins()
        {
            return db.Recorders.Where(r => r.DaragaId == 3 && !r.IsDeleted).Select(r => new RecorderDropDown { Id = r.Id, Name = r.Name }).ToList();
        }
        // for insert new recorder into db
        // POST: api/Recorders
        [ResponseType(typeof(Recorder))]
        public async Task<IHttpActionResult> PostRecorder(RecorderAddtionVM recorder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            Recorder r = new Recorder {Name = recorder.Name,DaragaId = recorder.DaragaId,IsDeleted = false};
            db.Recorders.Add(r);
            await db.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { id = r.Id }, r);
        }

        // DELETE: api/Recorders/5
        [ResponseType(typeof(Recorder))]
        public async Task<IHttpActionResult> DeleteRecorder(int id)
        {
            Recorder recorder = await db.Recorders.FindAsync(id);
            if (recorder == null)
            {
                return NotFound();
            }
            recorder.IsDeleted = true;
            //db.Recorders.Remove(recorder);
            await db.SaveChangesAsync();
            return Ok(recorder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecorderExists(int id)
        {
            return db.Recorders.Count(e => e.Id == id) > 0;
        }
    }
}