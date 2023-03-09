using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TransportationAkademiPlus.Models;

namespace TransportationAkademiPlus.Controllers
{
    public class LoginController : Controller
    {
        DbTransportEntities2 db = new DbTransportEntities2 ();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin p) 
        {
            var values = db.TblAdmin.FirstOrDefault(x => x.Username == p.Username & x.Password == p.Password);
            if (values != null) 
            {
                FormsAuthentication.SetAuthCookie(values.Username,false);
                Session["Username"] = p.Username.ToString();
                return RedirectToAction("Index","Profile");
            }

            return View();
        }
        
    }
}