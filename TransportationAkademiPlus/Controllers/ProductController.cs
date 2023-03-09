using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using TransportationAkademiPlus.Models;
namespace TransportationAkademiPlus.Controllers
{
    [Authorize]

    public class ProductController : Controller
    {
        // GET: Product
        DbTransportEntities2 db = new DbTransportEntities2 ();
        public ActionResult Index(int sayfa = 1)
        {
            var urunler = db.TblProduct.ToList().ToPagedList(sayfa, 5);
            return View(urunler);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> values = (from x in db.TblCategory
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()

                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(TblProduct tblProduct)
        {
            db.TblProduct.Add(tblProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            var value = db.TblProduct.Find(id);
            db.TblProduct.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var value = db.TblProduct.Find(id);
            List<SelectListItem> values = (from x in db.TblCategory
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()

                                           }).ToList();
            ViewBag.p = values;
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProduct(TblProduct tblProduct)
        {
            var value = db.TblProduct.Find(tblProduct.ProductID);
            value.ProductName = tblProduct.ProductName;
            value.ProductDescription = tblProduct.ProductDescription;
            value.ProductSize = tblProduct.ProductSize;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}