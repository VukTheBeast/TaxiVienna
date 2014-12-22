using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiWebSite.Controllers
{
    public class AGBController : Controller
    {
        // GET: AGB
        public ActionResult Index()
        {
            ViewBag.lang = Session["lang"];
            return View();
        }

        public ActionResult Ger()
        {
            //ViewBag.lang = Session["lang"];
            return PartialView("_ger");
        }

        public ActionResult Eng()
        {
            //ViewBag.lang = Session["lang"];
            return PartialView("_eng");
        }
    }
}