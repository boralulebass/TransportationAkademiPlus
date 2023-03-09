using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportationAkademiPlus.Models;

namespace TransportationAkademiPlus.Controllers
{
    [Authorize]
    public class RegisterController : Controller
    {
        // GET: Register
        DbTransportEntities2 db = new DbTransportEntities2 ();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin tbl)
        {
            db.TblAdmin.Add(tbl);
            db.SaveChanges();
            return RedirectToAction("Index","Register");
        }
    }
}