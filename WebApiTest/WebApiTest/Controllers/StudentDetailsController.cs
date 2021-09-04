using System;
using WebApiTest.Utility;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    public class StudentDetailsController : ApiController
    {
        private StudentDbEntities db = new StudentDbEntities();

        // GET: api/StudentDetails
        public IQueryable<tblStudentDetail> GettblStudentDetails()
        {

            Log.Info("Get request Api executed");
            return db.tblStudentDetails;
        }

        // GET: api/StudentDetails/5
        [ResponseType(typeof(tblStudentDetail))]
        public IHttpActionResult GettblStudentDetail(int id)
        {
            tblStudentDetail tblStudentDetail = db.tblStudentDetails.Find(id);
            if (tblStudentDetail == null)
            {
                Log.Info("Get - Request - Data not found");
                return NotFound();
            }

            Log.Info("Get request Api executed");
            return Ok(tblStudentDetail);
        }

        // PUT: api/StudentDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblStudentDetail(int id, tblStudentDetail tblStudentDetail)
        {
            

            if (id != tblStudentDetail.StudentId)
            {

                Log.Info("Put request - Bad Request");
                return BadRequest();

            }

            db.Entry(tblStudentDetail).State = EntityState.Modified;
            
            try
            {
                db.SaveChanges();
                Log.Info("Put request Executed");
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!tblStudentDetailExists(id))
                {
                    return NotFound();
                }
                else
                {

                    Log.Error("Put-Request" , ex);
                    return BadRequest("Handeled error occured");
                }
            }

            
        }

        // POST: api/StudentDetails
        [ResponseType(typeof(tblStudentDetail))]
        public IHttpActionResult PosttblStudentDetail(tblStudentDetail tblStudentDetail)
        {
            
            db.tblStudentDetails.Add(tblStudentDetail);
            db.SaveChanges();
            Log.Info("Post Request - Api Executed");
            return CreatedAtRoute("DefaultApi", new { id = tblStudentDetail.StudentId }, tblStudentDetail);
        }

        // DELETE: api/StudentDetails/5
        [ResponseType(typeof(tblStudentDetail))]
        public IHttpActionResult DeletetblStudentDetail(int id)
        {
            tblStudentDetail tblStudentDetail = db.tblStudentDetails.Find(id);
            if (tblStudentDetail == null)
            {
                return NotFound();
            }

            db.tblStudentDetails.Remove(tblStudentDetail);
            db.SaveChanges();
            Log.Info("Delete Reuest - Api Executed");
            return Ok(tblStudentDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblStudentDetailExists(int id)
        {
            return db.tblStudentDetails.Count(e => e.StudentId == id) > 0;
        }
    }
}