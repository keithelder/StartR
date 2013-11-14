using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StartR.Domain;
using StartR.Web.Infrastructure;
using System.Threading;
using System.Net.Http;

namespace StartR.Web.Controllers
{
    public class ClientController : Controller
    {
        private IStartRDataSource _db;

        public ClientController(IStartRDataSource db)
        {
            _db = db;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id = 0)
        {
            Client client = _db.Clients.Where(x => x.Id == id).FirstOrDefault();
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        public ActionResult Create()
        {
            return View();
        }

    }
}