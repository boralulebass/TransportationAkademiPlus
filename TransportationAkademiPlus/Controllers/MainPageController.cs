using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportationAkademiPlus.Models;

namespace TransportationAkademiPlus.Controllers
{
    public class MainPageController : Controller
    {

        DbTransportEntities2 db = new DbTransportEntities2 ();
        // GET: MainPage
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHeader()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialSlider()
        {
            return PartialView();
        }

        public PartialViewResult PartialAbout()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialDetail()
        {
            ViewBag.lefttitle1 = "Güvenli Taşımacılık";
            ViewBag.lefttitle2 = "Dünyanın Her Yerine Tüm Kargolar";
            ViewBag.lefttitle3 = "Konumu fark etmeksizin, doğudan batıya, kuzeyden güneye uzman ekibimizler güvenli teslimat yapıyoruz.";

            ViewBag.rightTitle1 = "Taşıma Kolaylığı";
            ViewBag.rightTitle2 = "Kendi ambalajlarımızla ile kargolarınızı paketliyoruz.";

            ViewBag.rightTitle3 = "Şehir İçi Dağıtım";
            ViewBag.rightTitle4 = "İstediğiniz saatte evlerinize veya belirlediğiniz yere teslimat yapmaktayız.";
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public PartialViewResult PartialMap()
        {
            return PartialView();
        }

        public PartialViewResult PartialFeatures() 
        {
            return PartialView();
        }

        public PartialViewResult PartialWays()
        {
            return PartialView();
        }

        public PartialViewResult PartialComment()
        {
            return PartialView();
        }

        public PartialViewResult PartialEmail() 
        {
            return PartialView();
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
    }
}