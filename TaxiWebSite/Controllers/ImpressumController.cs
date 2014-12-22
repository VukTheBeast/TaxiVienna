using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiWebSite.Controllers
{
    public class ImpressumController : Controller
    {
        // GET: Impressum
        public ActionResult Index()
        {
            ViewBag.lang = Session["lang"];
            return View();
        }
    }
}