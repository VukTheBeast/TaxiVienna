using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
                Dictionary<String, Int32> statistika = new Dictionary<String, int>() {
                                                            {"1",0},
                                                            {"2",0},
                                                            {"3",0},
                                                            {"4",0},
                                                            {"5",0},
                                                            {"6",0},
                                                            {"7",0},
                                                            {"8",0},
                                                            {"9",0},
                                                            {"10",0},
                                                            {"11",0},
                                                            {"12",0}}; 
                var stat = ukRezervacija.GroupBy(x => x.DatumVreme.Month)
                                            .Select(p => new { mesec = p.Key, count = p.Count() })
                                            .OrderBy(z => z.mesec)
                                            .ToList();

                foreach (var item in stat)
                {
                    statistika[item.mesec.ToString()] = item.count;
                }
          
            

           // IList<string> Data = new List<string>() { Jan, Feb, Mar, okt };

                return Json(statistika);
            }
        }
    }
}