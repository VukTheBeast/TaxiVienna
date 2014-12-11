using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiWebSite.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: AdminPanel
        public ActionResult AdminPanel()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DAL() {

            string Jan = "4";
            string Feb = "5";
            string Mar = "7";
            string okt = "15";

            IList<string> Data = new List<string>() { Jan, Feb, Mar, okt };

            return Json(new { Data });
        }
    }
}