using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TaxiWebSite.Models;

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
            
            using (var dbContext = new DB_9B8AB0_taxiEntities()) {
                var ukRezervacija = dbContext.Rezervacije.ToList();
                //var statistika = dbContext.Rezervacije.SqlQuery("select MONTH(DatumVreme), Count(DatumVreme) from Rezervacije group by Month(DatumVreme)");

                var r = (from statist in ukRezervacija
                         group statist by statist.DatumVreme.Month into statiGroup
                         orderby statiGroup.Key
                         select statiGroup).ToList();
                int jan = r.ElementAt(0).Count();
                //var result = dbContext.Rezervacije.GroupBy(m => m.DatumVreme.Month).ToList();
                //var result = from rez in ukRezervacija
                //             group rez by rez.DatumVreme.Month into Mesec
                //             select Mesec;
            }
            string Jan = "4";
            string Feb = "5";
            string Mar = "7";
            string okt = "15";

            IList<string> Data = new List<string>() { Jan, Feb, Mar, okt };

            return Json(new { Data });
        }
    }
}