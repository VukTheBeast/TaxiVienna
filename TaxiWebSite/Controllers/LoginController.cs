using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiWebSite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String password, String loginname)
        {

            string uname = System.Configuration.ConfigurationManager.AppSettings["adminUname"].ToString(); ;
            string pass = System.Configuration.ConfigurationManager.AppSettings["adminPass"].ToString(); ;

            if (uname.Equals(loginname) && pass.Equals(password))
            {
                Session["login"] = true;
                return RedirectToAction("AdminPanel", "AdminPanel");
            }
            else {
                TempData["poruka"] = "Wrong username or password";
                return RedirectToAction("Index");
            }
        }
        public ActionResult Logout() {
            Session["login"] = null;
            return RedirectToAction("Index");
        }

    }
}