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
using byNadiaRapti.Models;

namespace byNadiaRapti.Controllers
{
    public class ImagesController : ApiController
    {
        private NadiaDbEntities db = new NadiaDbEntities();

        // GET api/Images
        //public IQueryable<Images> GetImages()
        //{
        //    return db.Images;
        //}

        public List<ImagesInfo> GetImages()
        {
            var result = (from i in db.Images
                          select new ImagesInfo
                          {
                              Id = i.Id,
                              Priority = i.Priority,
                              Path = i.Path,
                              Desc = i.Description
                          }).OrderBy(x => x.Priority).ThenBy(x => x.Id).ToList();
            return result;
        }

        // GET api/Images/5
        [ResponseType(typeof(Images))]
        public async Task<IHttpActionResult> GetImages(int id)
        {
            Images images = await db.Images.FindAsync(id);
            if (images == null)
            {
                return NotFound();
            }

            return Ok(images);
        }

        // PUT api/Images/5
        public async Task<IHttpActionResult> PutImages(int id, Images images)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != images.Id)
            {
                return BadRequest();
            }

            db.Entry(images).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagesExists(id))
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

        // POST api/Images
        [ResponseType(typeof(Images))]
        public async Task<IHttpActionResult> PostImages(Images images)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Images.Add(images);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = images.Id }, images);
        }

        // DELETE api/Images/5
        [ResponseType(typeof(Images))]
        public async Task<IHttpActionResult> DeleteImages(int id)
        {
            Images images = await db.Images.FindAsync(id);
            if (images == null)
            {
                return NotFound();
            }

            db.Images.Remove(images);
            await db.SaveChangesAsync();

            return Ok(images);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImagesExists(int id)
        {
            return db.Images.Count(e => e.Id == id) > 0;
        }
    }
}