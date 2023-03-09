using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportationAkademiPlus.Models;
using PagedList.Mvc;

namespace AkademiPlus_Transportation.Controllers
{
    [Authorize]

    public class CustomerController : Controller
    {
        DbTransportEntities2 db = new DbTransportEntities2();
        //Lambda Expression  a=> a.
        public ActionResult Index(int sayfa=1)
        {
            var values = db.TblCustomer.ToList().ToPagedList(sayfa,5);
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(TblCustomer tblCustomer)
        {
            db.TblCustomer.Add(tblCustomer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            var value = db.TblCustomer.Find(id);
            db.TblCustomer.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCustomer(int id)
        {
            var value = db.TblCustomer.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCustomer(TblCustomer tblCustomer)
        {
            var value = db.TblCustomer.Find(tblCustomer.CustomerID);
            value.CustomerName = tblCustomer.CustomerName;
            value.CustomerSurname = tblCustomer.CustomerSurname;
            value.CustomerCity = tblCustomer.CustomerCity;
            value.CustomerPhone = tblCustomer.CustomerPhone;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}