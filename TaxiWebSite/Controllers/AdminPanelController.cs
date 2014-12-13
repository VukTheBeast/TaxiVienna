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
    public class FromAir {
        public String datum { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string adresa { get; set; }
        public string price { get; set; }
        public string phone { get; set; }
    
    
    }
    public class AdminPanelController : Controller
    {

          // GET: AdminPanel
        public ActionResult AdminPanel()
        {
            if (Session["login"] != null)
                return View();
            else {
                return RedirectToAction("Index", "Login");
            
            }
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

        public ActionResult Voznje() {
            if (Session["login"] != null){
                using(var dbContext=new DB_9B8AB0_taxiEntities()){

                    DateTime dt = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
                    var rezFrom = dbContext.Rezervacije.Where(x => x.FromToAirport.Equals("from airport"))
                                                        .Where(d => d.DatumVreme >= dt)
                                                        .OrderBy(y => y.DatumVreme)
                                                        .ToList();
                    List<FromAir> from=new List<FromAir>();

                  


                    //JBGN VISUAL STUDIO IMA BAG I OVO NECE DA RADI!!!!!!
                    //var rezFrom = dbContext.Rezervacije.Where(x => x.FromToAirport.Equals("from airport"))
                    //                                    .Where(d => d.DatumVreme >= dt)
                    //                                    .Select(m => new {datum=m.DatumVreme, email=m.Korisnici.Email, ulica=m.Korisnici.Ulice.Name })
                    //                                    .OrderBy(y => y.datum)
                    //                                    .ToList();

                    
                    foreach (var item in rezFrom)
                    {
                        FromAir a = new FromAir();
                        a.adresa =item.Korisnici.Ulice.Oblasti.Gradovi.Name+ " / "+ item.Korisnici.Ulice.Oblasti.Name+" / "+ item.Korisnici.Ulice.Name;
                        a.name = item.Korisnici.Name;
                        a.email = item.Korisnici.Email;
                        a.datum = item.DatumVreme.ToString();
                        a.price = item.Price.ToString();
                        a.phone = item.Korisnici.Telefon;
                        from.Add(a);
                    }

                    ViewBag.from = from;
                    //rezFrom[0].Korisnici.Ulice


                    List<FromAir> toAirport= new List<FromAir>();

                    var rezTo= dbContext.Rezervacije.Where(x => x.FromToAirport.Equals("to airport"))
                                                      .Where(d => d.DatumVreme >= dt)
                                                      .OrderBy(y => y.DatumVreme)
                                                      .ToList();

                    foreach (var item in rezTo)
                    {
                        FromAir a = new FromAir();
                        a.adresa = item.Korisnici.Ulice.Oblasti.Gradovi.Name + " / " + item.Korisnici.Ulice.Oblasti.Name + " / " + item.Korisnici.Ulice.Name;
                        a.name = item.Korisnici.Name;
                        a.email = item.Korisnici.Email;
                        a.datum = item.DatumVreme.ToString();
                        a.price = item.Price.ToString();
                        a.phone = item.Korisnici.Telefon;
                        toAirport.Add(a);
                    }

                    ViewBag.to = toAirport;





                return View();
              }
            }
            else
            {
                return RedirectToAction("Index", "Login");

            }
        
        }
    
    }
}