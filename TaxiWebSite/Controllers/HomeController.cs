using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiWebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["lang"] == null)
            {
                Session["lang"] = "ger";
            }
            ViewBag.lang = Session["lang"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.lang = Session["lang"];

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.lang = Session["lang"];
            return View();
        }

        public ActionResult Price() {
            ViewBag.Message = "See what is our price.";

            return View();
        }

        [HttpPost]
        public void SetSession(string lang) {
            Session["lang"] = lang;
        }
     
    }
}