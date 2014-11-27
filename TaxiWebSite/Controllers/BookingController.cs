using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult BookingDOAerodroma(String pickUpDate, String pickUpTime, String pickUpFrom, String fullName, String location,
                                                String zipCode, String phone, String email, String typeOfCar, String suitcases, String handLaggage, String payment, String street)
        {
            String poruka = "Vasa rezervacija je poslata vozacu. Proverite mejl da li vam je potvrdjena rezervacija";

           
           
           // String googleMapsLocation=location+","+zipCode+","+street;
            String googleMapsLocation = "https://www.google.at/maps?q=" + location + "," + street;
            String confirmString = "http://localhost:2190/Booking/ConfirmBooking?email="+Server.UrlEncode(email);


            StringBuilder sb = new StringBuilder("<table border=\"1\"><tbody><tr><td>Pick Up-Date</td><td>");
            sb.Append(pickUpDate+"</td></tr><tr><td>Pick Up-From</td><td>");
            sb.Append(pickUpFrom + "</td></tr><tr><td>Full Name</td><td>");
            sb.Append(fullName+"</td></tr><tr><td>Location</td><td>");
            sb.Append(location+"</td></tr><tr><td>Zip Code</td><td>");
            sb.Append(zipCode+"</td></tr><tr><td>Street</td><td>");
            sb.Append(street+"</td></tr><tr><td>Phone</td><td>");
            sb.Append(phone+"</td></tr><tr><td>Email</td><td><a href=\"mailto:"+email+"\">");
            sb.Append(email+"</a></td></tr><tr><td>Type of Car</td><td>");
            sb.Append(typeOfCar+"</td></tr><tr><td>Suitcases</td><td>");
            sb.Append(suitcases+"</td></tr><tr><td>Handlaggage</td><td>");
            sb.Append(handLaggage+"</td></tr><tr><td>Payment</td><td>");
            sb.Append(payment+"</td></tr><tr><td>See location</td><td><a href=\"");
            sb.Append(googleMapsLocation+"\">See Location</a></td></tr><tr><td>Confirm</td><td><a href=\"");
            sb.Append(confirmString+"\">Confirm</a></td></tr></tbody></table>");
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
                client.Credentials = new System.Net.NetworkCredential("gavra90@gmail.com", "ovde unesite vasu sifru i mejl");
               // client.Credentials = System.Net.CredentialCache.DefaultCredentials;

                MailMessage mm = new MailMessage(email, "dejan.gavrilovic@vs.rs");
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
        
        
        
        }
    }
}