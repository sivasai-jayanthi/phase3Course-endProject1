using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace WebApplication3.Controllers
{
    public class EmpProfilesController : ApiController
    {
        private EmployeeDbContext db = new EmployeeDbContext();

        // GET: api/EmpProfiles
        public IQueryable<EmpProfile> GetEmpProfiles()
        {
            return db.EmpProfiles;
        }

        // GET: api/EmpProfiles/5
        [ResponseType(typeof(EmpProfile))]
        public IHttpActionResult GetEmpProfile(int id)
        {
            EmpProfile empProfile = db.EmpProfiles.Find(id);
            if (empProfile == null)
            {
                return NotFound();
            }

            return Ok(empProfile);
        }

        // PUT: api/EmpProfiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpProfile(int id, EmpProfile empProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empProfile.EmpCode)
            {
                return BadRequest();
            }

            db.Entry(empProfile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpProfileExists(id))
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

        // POST: api/EmpProfiles
        [ResponseType(typeof(EmpProfile))]
        public IHttpActionResult PostEmpProfile(EmpProfile empProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmpProfiles.Add(empProfile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empProfile.EmpCode }, empProfile);
        }

        // DELETE: api/EmpProfiles/5
        [ResponseType(typeof(EmpProfile))]
        public IHttpActionResult DeleteEmpProfile(int id)
        {
            EmpProfile empProfile = db.EmpProfiles.Find(id);
            if (empProfile == null)
            {
                return NotFound();
            }

            db.EmpProfiles.Remove(empProfile);
            db.SaveChanges();

            return Ok(empProfile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpProfileExists(int id)
        {
            return db.EmpProfiles.Count(e => e.EmpCode == id) > 0;
        }
    }
}