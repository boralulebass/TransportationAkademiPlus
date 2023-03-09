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

    public class EmployeeController : Controller
    {
        DbTransportEntities2 db = new DbTransportEntities2();
        public ActionResult Index(int sayfa = 1)
        {
            var values = db.TblEmployee.ToList().ToPagedList(sayfa,2);
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(TblEmployee tblEmployee)
        {
            db.TblEmployee.Add(tblEmployee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            var value = db.TblEmployee.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(TblEmployee tblEmployee)
        {
            var value = db.TblEmployee.Find(tblEmployee.EmployeeID);
            value.EmployeeName = tblEmployee.EmployeeName;
            value.EmployeeSurname = tblEmployee.EmployeeSurname;
            value.Employeeimage = tblEmployee.Employeeimage;
            value.EmployeeDescription = tblEmployee.EmployeeDescription;
            value.EmployeeMail = tblEmployee.EmployeeMail;
            value.EmployeeEducation = tblEmployee.EmployeeEducation;
            value.EmployeeLocation = tblEmployee.EmployeeLocation;
            value.EmployeeSkills = tblEmployee.EmployeeSkills;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEmployee(int id)
        {
            var value = db.TblEmployee.Find(id);
            db.TblEmployee.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}