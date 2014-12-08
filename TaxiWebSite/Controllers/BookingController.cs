using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TaxiWebSite.Models;

namespace TaxiWebSite.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Booking()
        {
            ViewBag.Message = "Order from/to Airport";
            return View();
        }

        public ActionResult BookingDOAerodroma(String pickUpDate, String pickUpTime,String house,String flor, String door, 
                                                String pickUpFrom, String fullName, String location,
                                                String zipCode, String phone, String email, String typeOfCar, String suitcases,
                                                    String handLaggage, String payment, String street, String comment, String isReturn,
                                                 String ReturnDate, String ReturnTime)
        {
            String poruka = "Vasa rezervacija je poslata vozacu. Proverite mejl da li vam je potvrdjena rezervacija";

           
           
           // String googleMapsLocation=location+","+zipCode+","+street;
            String googleMapsLocation = "https://www.google.at/maps?q=" + location + "," + street;
            String domain=System.Configuration.ConfigurationManager.AppSettings["domain"].ToString();
            String confirmString = domain + "/Booking/ConfirmBooking?email="+Server.UrlEncode(email);



            StringBuilder sb = new StringBuilder("<table border=\"1\"><tbody><tr><td>Pick Up-Date</td><td>");
            sb.Append(pickUpDate+"</td></tr><tr><td>Pick Up-From</td><td>");
            sb.Append(pickUpFrom + "</td></tr><tr><td>Price</td><td>");
            sb.Append("Price dodaj" + "</td></tr><tr><td>Full Name</td><td>");
            sb.Append(fullName+"</td></tr><tr><td>Location</td><td>");
            sb.Append(location+"</td></tr><tr><td>Zip Code</td><td>");
            sb.Append(zipCode+"</td></tr><tr><td>Street</td><td>");
            sb.Append(street+"</td></tr><tr><td>House</td><td>");
            sb.Append(house+"/"+flor+"/"+door + "</td></tr><tr><td>Phone</td><td>");
            sb.Append(phone+"</td></tr><tr><td>Email</td><td><a href=\"mailto:"+email+"\">");
            sb.Append(email+"</a></td></tr><tr><td>Type of Car</td><td>");
            sb.Append(typeOfCar+"</td></tr><tr><td>Suitcases</td><td>");
            sb.Append(suitcases+"</td></tr><tr><td>Handlaggage</td><td>");
            sb.Append(handLaggage + "</td></tr><tr><td>Comment</td><td>");
            sb.Append(comment+"</td></tr><tr><td>Payment</td><td>");
            sb.Append(payment+"</td></tr><tr><td>See location</td><td><a href=\"");
            sb.Append(googleMapsLocation+"\">See Location</a></td></tr><tr><td>Confirm</td><td><a href=\"");
            sb.Append(confirmString+"\">Confirm</a></td></tr></tbody></table><br/><br/>");

            if (!isReturn.Equals("false"))
            {
                sb.Append("<br/><br/><table border=\"1\"><tbody><tr><td>Return Date</td><td>");
                sb.Append(ReturnDate + "</td></tr><tr><td>Return Time</td><td>");
                sb.Append(ReturnTime + "</td></tr></tbody></table>");

            }

            sb.Append("Web Developer Team dvig.rs");


       

            try
            {

                /****ovde samo kad se kreira client dodaj ovo (SmtpClient mailClient = new SmtpClient("your.emailgateway.com"); mailClient.Send(message);) da ne bi trazio autentifikaciju***/
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("007flughafentaxi@gmail.com", "nautilus142");
               // client.Credentials = System.Net.CredentialCache.DefaultCredentials;

                MailMessage mm = new MailMessage(email, "007flughafentaxi@gmail.com");
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mm.Subject = fullName + "[reservation]";
                mm.IsBodyHtml = true;
                mm.Body = sb.ToString();
                client.Send(mm);


            }
            catch (Exception ex)
            {

                poruka = "Greska prilikom slanja mejla";
            }
          



            return Json(new { poruka = poruka });
        }

        public void ConfirmBooking(String email) {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("007flughafentaxi@gmail.com", "nautilus142");
                // client.Credentials = System.Net.CredentialCache.DefaultCredentials;

                MailMessage mm = new MailMessage("007flughafentaxi@gmail.com", email);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mm.Subject = "Confirm reservation";
               // mm.IsBodyHtml = true;
                mm.Body ="Your reservation is confirmed. The driver will come to you in next half hour.";
                client.Send(mm);

                Response.ClearHeaders();
                Response.ContentType = "text/html";
                // Response.AddHeader("content-disposition", attachment;filename='Test.csv'");
                Response.Write("<h1 style=\"text-align:center\">Rezervacija je potvrdjena.</h1>");
                Response.End();

            }
            catch (Exception ex)
            {
                Response.ClearHeaders();
                Response.ContentType = "text/html";
                // Response.AddHeader("content-disposition", attachment;filename='Test.csv'");
                Response.Write(ex.Message);
                Response.End();
               
            }
        }

        [HttpPost]
        public string ListaUlica(int? id)
        {
            using (var context = new DB_9B8AB0_taxiEntities())
            {               

                var ListaUlica = context.ListaUlica(id).ToList();

                //lambda izraz za spisak ulica kao alternativa stored procedure-i
                //var lista = context.Ulice.Where(s => s.Id == id).Select(s => new SelectListItem { Value = s.Name, Text = s.Id.ToString() });
               
                //linq izraz za spisak ulica kao alternativa stored procedure-i
                /*IEnumerable<SelectListItem> ulice =
                    from ulica in context.Ulice
                    where ulica.Id == id
                    select new SelectListItem { Value = ulica.Name, Text = ulica.Id.ToString() };*/               


                StringBuilder sb = new StringBuilder("<select id=\"street\" name=\"street\">");
                if (ListaUlica.Count() > 0) sb.Append("<option value=\"\"></option>");
                foreach (TaxiWebSite.Models.ListaUlica_Result item in ListaUlica)
                {
                    sb.Append("<option value=\"" + item.Id + "\" >" + item.Name + "</option>");

                }
                sb.Append("</select>&nbsp;<label for=\"street\" class=\"error\" generated=\"true\"></label>");

                return sb.ToString();
            }
            //IEnumerable<BookingDataModel> ListaUlica = BookingModel.ListaUlica(id, tekst);
            
            
            
        }

        [HttpPost]
        public string ListaOblasti(int id)
        {
            //IEnumerable<BookingDataModel> ListaOblasti = BookingModel.ListaOblasti(id);

            using (var context = new DB_9B8AB0_taxiEntities())
            {
                //var result = (from c in context.Gradovi select new { c.Id, c.Name });

                var ListaOblasti = context.ListaOblasti(id).ToList();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                //String js = jss.Serialize(ListaUlica);
                //return Json(js);
                
                StringBuilder sb = new StringBuilder("<select id=\"InputZipCode\" name=\"InputZipCode\">");
                if (ListaOblasti.Count() > 0) sb.Append("<option value=\"\"></option>");
                foreach (TaxiWebSite.Models.ListaOblasti_Result item in ListaOblasti)
                {
                    sb.Append("<option value=\"" + item.Id + "\" >" + item.Name + "</option>");

                }
                sb.Append("</select>&nbsp;<label for=\"InputZipCode\" class=\"error\" generated=\"true\"></label>");

                return sb.ToString();
            }

            
        }

    }
}