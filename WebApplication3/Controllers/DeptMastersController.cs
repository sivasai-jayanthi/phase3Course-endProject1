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
    public class DeptMastersController : ApiController
    {
        private EmployeeDbContext db = new EmployeeDbContext();

        // GET: api/DeptMasters
        public IQueryable<DeptMaster> GetDeptMasters()
        {
            return db.DeptMasters;
        }

        // GET: api/DeptMasters/5
        [ResponseType(typeof(DeptMaster))]
        public IHttpActionResult GetDeptMaster(int id)
        {
            DeptMaster deptMaster = db.DeptMasters.Find(id);
            if (deptMaster == null)
            {
                return NotFound();
            }

            return Ok(deptMaster);
        }

        // PUT: api/DeptMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeptMaster(int id, DeptMaster deptMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deptMaster.DeptCode)
            {
                return BadRequest();
            }

            db.Entry(deptMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeptMasterExists(id))
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

        // POST: api/DeptMasters
        [ResponseType(typeof(DeptMaster))]
        public IHttpActionResult PostDeptMaster(DeptMaster deptMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DeptMasters.Add(deptMaster);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = deptMaster.DeptCode }, deptMaster);
        }

        // DELETE: api/DeptMasters/5
        [ResponseType(typeof(DeptMaster))]
        public IHttpActionResult DeleteDeptMaster(int id)
        {
            DeptMaster deptMaster = db.DeptMasters.Find(id);
            if (deptMaster == null)
            {
                return NotFound();
            }

            db.DeptMasters.Remove(deptMaster);
            db.SaveChanges();

            return Ok(deptMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeptMasterExists(int id)
        {
            return db.DeptMasters.Count(e => e.DeptCode == id) > 0;
        }
    }
}