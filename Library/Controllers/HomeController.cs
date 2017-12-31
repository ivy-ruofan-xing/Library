using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private BookDBContext db = new BookDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Having trouble? Contact us!";

            return View();
        }
    }
}