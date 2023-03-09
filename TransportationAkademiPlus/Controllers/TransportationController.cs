using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportationAkademiPlus.Models;
using PagedList.Mvc; 

namespace TransportationAkademiPlus.Controllers
{
    [Authorize]
    public class TransportationController : Controller
    {
        // GET: Transportation
        DbTransportEntities2 db = new DbTransportEntities2 ();
        public ActionResult Index(int sayfa=1)
        {
            var values = db.TblTransportation.ToList().ToPagedList(sayfa,5);
            return View(values);
        }
        [HttpGet]
        public ActionResult AddTransportation()
        {
            List<SelectListItem> values = (from x in db.TblCustomer
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerName,
                                               Value = x.CustomerID.ToString()

                                           }).ToList();
            List<SelectListItem> values1 = (from x in db.TblCategory
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()

                                           }).ToList();
            List<SelectListItem> values2 = (from x in db.TblProduct
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()

                                           }).ToList();
            List<SelectListItem> values3 = (from x in db.TblEmployee
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName,
                                               Value = x.EmployeeID.ToString()

                                           }).ToList();
            List<SelectListItem> values4 = (from x in db.TblProcess
                                            select new SelectListItem
                                            {
                                                Text = x.Description,
                                                Value = x.ProcessID.ToString()

                                            }).ToList();
            ViewBag.v = values;
            ViewBag.p = values1;
            ViewBag.p2 = values2;
            ViewBag.p3 = values3;
            ViewBag.p4 = values4;
            return View();
        }
        [HttpPost]
        public ActionResult AddTransportation(TblTransportation transportation)
        {
            db.TblTransportation.Add(transportation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTransportation(int id)
        {
            var value = db.TblTransportation.Find(id);
            db.TblTransportation.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTransportation(int id)
        {
            var value = db.TblTransportation.Find(id);
            List<SelectListItem> values = (from x in db.TblCustomer
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerName,
                                               Value = x.CustomerID.ToString()

                                           }).ToList();
            List<SelectListItem> values1 = (from x in db.TblCategory
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryID.ToString()

                                            }).ToList();
            List<SelectListItem> values2 = (from x in db.TblProduct
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName,
                                                Value = x.ProductID.ToString()

                                            }).ToList();
            List<SelectListItem> values3 = (from x in db.TblEmployee
                                            select new SelectListItem
                                            {
                                                Text = x.EmployeeName,
                                                Value = x.EmployeeID.ToString()

                                            }).ToList();
            List<SelectListItem> values4 = (from x in db.TblProcess
                                            select new SelectListItem
                                            {
                                                Text = x.Description,
                                                Value = x.ProcessID.ToString()

                                            }).ToList();
            ViewBag.v = values;
            ViewBag.p = values1;
            ViewBag.p2 = values2;
            ViewBag.p3 = values3;
            ViewBag.p4 = values4;
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTransportation(TblTransportation transportation)
        {
            var value = db.TblTransportation.Find(transportation.TransportationID);

            value.Customer = transportation.Customer;
            value.Product = transportation.Product;
            value.Employee = transportation.Employee;
            value.Category = transportation.Category;
            value.Status = transportation.Status;
            value.Departure = transportation.Departure;
            value.Arrival = transportation.Arrival;
            value.Date = transportation.Date;
            value.Description = transportation.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}