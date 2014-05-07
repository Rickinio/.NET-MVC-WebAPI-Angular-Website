using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace byNadiaRapti.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Header()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Collections()
        {
            return View();
        }
    }
}
