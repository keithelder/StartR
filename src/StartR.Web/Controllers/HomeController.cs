using StartR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StartR.Web.Controllers
{
    public class HomeController : Controller
    {
        private IStartRDataSource _db;

        public HomeController(IStartRDataSource db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Clients);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
