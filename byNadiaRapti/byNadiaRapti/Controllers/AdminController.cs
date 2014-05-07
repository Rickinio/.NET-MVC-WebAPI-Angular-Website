using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using byNadiaRapti.Models;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

namespace byNadiaRapti.Controllers
{
    public class AdminController : Controller
    {
        NadiaDbEntities db = new NadiaDbEntities();
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            var Categories = db.Categories.ToList();
            return View(Categories);
        }

        [HttpPost]
        public ActionResult Index(UploadedImagesDetails UploadedFiles)
        {
            foreach (var file in UploadedFiles.Files)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Collections"), fileName);
                    file.SaveAs(path);

                    var img = new Images();
                    img.Path = fileName;
                    img.Description = Path.GetFileNameWithoutExtension(file.FileName);
                    img.Categories_Id = int.Parse(UploadedFiles.Category);
                    db.Images.Add(img);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetImages(int Id)
        {

            var result = (from i in db.Images
                          where i.Categories_Id == Id 
                          select new ImagesInfo
                          {
                              Priority = i.Priority,
                              Id = i.Id,
                              Path = i.Path,
                              Desc = i.Description
                          }).OrderBy(x => x.Priority).ThenBy(x => x.Id).ToList();
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        private T Deserialise<T>(string json)
        {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serialiser = new DataContractJsonSerializer(typeof(T));
                return (T)serialiser.ReadObject(ms);
            }
        }
        [HttpPost]
        public void RepositionPhotos(string data)
        {
            IEnumerable<ImagesOrder> imgOrder = Deserialise<IEnumerable<ImagesOrder>>(data);
            foreach(var photo in imgOrder){
                var photoToUpdate = db.Images.Single(x => x.Id == photo.id);
                photoToUpdate.Priority = photo.index;
            }
            db.SaveChanges();
        }


	}
}