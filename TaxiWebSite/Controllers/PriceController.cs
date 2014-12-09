using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiWebSite.Controllers
{
    public class PriceController : Controller
    {
        // GET: Price
        public ActionResult getPrice()
        {
            string filePath = Server.MapPath(Url.Content("~/Cena/Prices.pdf"));
           // byte[] pdfByte = System.IO.File.ReadAllBytes(filePath);

            return File(filePath, "application/pdf");
        }
    }
}