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
using DSCConfigurationManagement.Models;

namespace DSCConfigurationManagement.Controllers
{
    public class MyGuidsController : ApiController
    {
        private DSCConfigurationManagementContext db = new DSCConfigurationManagementContext();

        // GET: api/MyGuids
        public IQueryable<MyGuid> GetMyGuids()
        {
            return db.MyGuids;
        }

        // GET: api/MyGuids/5
        [ResponseType(typeof(MyGuid))]
        public async Task<IHttpActionResult> GetMyGuid(int id)
        {
            MyGuid myGuid = await db.MyGuids.FindAsync(id);
            if (myGuid == null)
            {
                return NotFound();
            }

            return Ok(myGuid);
        }

        // PUT: api/MyGuids/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMyGuid(int id, MyGuid myGuid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != myGuid.ID)
            {
                return BadRequest();
            }

            db.Entry(myGuid).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyGuidExists(id))
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

        // POST: api/MyGuids
        [ResponseType(typeof(MyGuid))]
        public async Task<IHttpActionResult> PostMyGuid(MyGuid myGuid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MyGuids.Add(myGuid);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = myGuid.ID }, myGuid);
        }

        // DELETE: api/MyGuids/5
        [ResponseType(typeof(MyGuid))]
        public async Task<IHttpActionResult> DeleteMyGuid(int id)
        {
            MyGuid myGuid = await db.MyGuids.FindAsync(id);
            if (myGuid == null)
            {
                return NotFound();
            }

            db.MyGuids.Remove(myGuid);
            await db.SaveChangesAsync();

            return Ok(myGuid);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MyGuidExists(int id)
        {
            return db.MyGuids.Count(e => e.ID == id) > 0;
        }
    }
}