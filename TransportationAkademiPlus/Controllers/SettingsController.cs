using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportationAkademiPlus.Models;

namespace TransportationAkademiPlus.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        DbTransportEntities2 db = new DbTransportEntities2 ();
        // GET: Settings
        [HttpGet]
        public ActionResult Index()
        {
            var values = Session["Username"];
            var uservalue = db.TblAdmin.Where(x=>x.Username == values.ToString()).FirstOrDefault();
            return View(uservalue);
        }
        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {

            return View();
        }
    }
}