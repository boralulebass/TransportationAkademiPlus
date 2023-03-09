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

    public class CategoryController : Controller
    {
        DbTransportEntities2 db = new DbTransportEntities2();
        public ActionResult Index(int sayfa=1)
        {
            var values = db.TblCategory.ToList().ToPagedList(sayfa, 3);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(TblCategory tblCategory)
        {
            db.TblCategory.Add(tblCategory);
            db.SaveChanges(); //adonet--> executenonquery
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = db.TblCategory.Find(id);
            db.TblCategory.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = db.TblCategory.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(TblCategory tblCategory)
        {
            var value = db.TblCategory.Find(tblCategory.CategoryID);
            value.CategoryName = tblCategory.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
//Attribute --> üstünde bulunduğu alanın ne iş yapacağını bildirir.
/*
 ToList
 Add
 Find
 Remove
 */