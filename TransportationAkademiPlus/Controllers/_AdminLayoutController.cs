using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportationAkademiPlus.Models;

namespace TransportationAkademiPlus.Controllers
{
    public class _AdminLayoutController : Controller
    {
        // GET: _AdminLayout
        DbTransportEntities2 db = new DbTransportEntities2();

        public ActionResult _AdminLayout()
        {  
            return View();
        }
        public PartialViewResult Siparis()
        {
            ViewBag.Siparis = db.TblTransportation.Count(x => x.Status.ToString() != "Teslim Edildi");
            return PartialView();
        }

        public PartialViewResult Calisan()
        {
            ViewBag.Calisan = db.TblEmployee.Count();
            return PartialView();
        }
        public PartialViewResult Islem()
        {
            ViewBag.Islem = db.TblTransportation.Count(x => x.TblProcess.Description.ToString() == "Yolda");
            return PartialView();
        }
        public PartialViewResult Musteri()
        {
            ViewBag.Musteri = db.TblCustomer.Count();
            return PartialView();
        }





    }
}