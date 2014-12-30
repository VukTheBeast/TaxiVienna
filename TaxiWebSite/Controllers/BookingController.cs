using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
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
            ViewBag.lang = Session["lang"];
            using (var dbContext = new DB_9B8AB0_taxiEntities()) {

                var list = dbContext.Gradovi.ToList();
                var oblastiWien = dbContext.Oblasti.Where(x => x.Id_Grada.Equals(1)).ToList();
                
                List<SelectListItem> listaGradovi = new List<SelectListItem>();

                foreach (var item in list)
                {
                    listaGradovi.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
                }

                ViewBag.listaGradovi = listaGradovi;



                List<SelectListItem> listaOblastiWien = new List<SelectListItem>();

                listaOblastiWien.Add(new SelectListItem { Text = "Pick Up Area", Value = "" });
                foreach (var item in oblastiWien)
                {
                    listaOblastiWien.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
                }

                ViewBag.listaOblastiWien = listaOblastiWien;
            
                

            return View();
            }
        }

        public ActionResult BookingDOAerodroma(String pickUpDate, String pickUpTime,String house,String flor, String door, 
                                                String pickUpFrom, String fullName, String location,
                                                String zipCode, String phone, String email, String typeOfCar, String suitcases,
                                                String handLaggage, String payment, String street, String comment, String isReturn,
                                                String ReturnDate, String ReturnTime, String price, String ID_Ulice)
        {
             String poruka="Your reservation has been sent to the driver. Check your email for confirmation.";
            if (!Session["lang"].ToString().Equals("ger")) 
                 poruka = "Your reservation has been sent to the driver. Check your email for confirmation.";
            else
                poruka = "Ihre Reservierung ist für den Fahrer übergeben. Überprüfen Sie Ihre E-Mail zur Bestätigung.";

            int idRezervacije = 0;
            try
            {
                using (var dbContext = new DB_9B8AB0_taxiEntities())
                {
                    var korisnik = dbContext.Korisnici.Where(x => x.Email.Equals(email)).SingleOrDefault();//proveravam da li imamo korisnika u bazu
                    int idKorisnika;
                    if (korisnik == null)//onda se dodaje u tabelu korisnika i upisuje tabela rezervacija
                    {
                      //  ID_Ulice = "1";//ovo je za test skini posle
                        Korisnici k = new Korisnici();
                        k.Email = email;
                        k.Name = fullName;
                        k.Telefon = phone;
                        k.UkupnoVoznje = 0;
                        k.BrojVoznje = 0;
                        k.UliceId = Convert.ToInt32(ID_Ulice);

                        dbContext.Korisnici.Add(k);
                        dbContext.SaveChanges();

                        idKorisnika = k.ID;
                    }
                    else
                        idKorisnika = korisnik.ID;

                    var rez = new Rezervacije();
                    rez.KorisniciID = idKorisnika;
                    rez.Payment = payment;

                    price = price.Substring(0, price.Length - 1);
                    rez.Price = Convert.ToDouble(price);
                    // rez.Suitcases = suitcases;
                    rez.FromToAirport = "to airport";
                    rez.IsConfirmed = false;
                    rez.CarType = typeOfCar;
                    rez.Id_Ulice = Convert.ToInt32(ID_Ulice);
                    String[] s = pickUpDate.Split('-');
                    pickUpDate = s[2] + "-" + s[1] + "-" + s[0] + " " + pickUpTime;

                    DateTime dt = DateTime.ParseExact(pickUpDate, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

                  //  DateTime dt = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
                    rez.DatumVreme = dt;
                    

                    dbContext.Rezervacije.Add(rez);

                    korisnik.Name = fullName;
                    korisnik.Email = email;
                    korisnik.UliceId = Convert.ToInt32(ID_Ulice);

                    dbContext.SaveChanges();

                    idRezervacije = rez.ID;
                }

            }
            catch (Exception ex)
            {
                //ovde zapamti log
                throw ex;
            }

            //CancleBooking

           // String googleMapsLocation=location+","+zipCode+","+street;
            String googleMapsLocation = "https://www.google.at/maps?q=" + location + "," + street;
            String domain=System.Configuration.ConfigurationManager.AppSettings["domain"].ToString();
            //String confirmString = domain + "/Booking/ConfirmBooking?email="+Server.UrlEncode(email);
            String confirmString = domain + "/Booking/ConfirmBooking?email=" + idRezervacije +"&lang=" +Session["lang"].ToString();
            String cancleBooking = domain + "/Booking/CancleBooking?email=" + idRezervacije;

            StringBuilder sb = new StringBuilder("<table border=\"1\"><tbody><tr><td>Pick Up-Date</td><td>");
            sb.Append(pickUpDate+"  "+pickUpTime+"</td></tr><tr><td>Pick Up-From</td><td>");
            sb.Append(pickUpFrom + "</td></tr><tr><td>Price</td><td>");
            sb.Append(price + "</td></tr><tr><td>Cancle Booking</td><td><a href=\"");
            sb.Append(cancleBooking + "\">Cancle Booking</a></td></tr><tr><td>Full Name</td><td>");
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
                client.Host = "smtp.gmail.com"; //ovo treba da se doradi na mejl server hostinga
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("007flughafentaxi@gmail.com", "nautilus142");
               // client.Credentials = System.Net.CredentialCache.DefaultCredentials;

                MailMessage mm = new MailMessage(email, "flughafentaxibond@gmail.com");
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mm.Subject = fullName + "[To Airport]";
                mm.IsBodyHtml = true;
                mm.Body = sb.ToString();
                client.Send(mm);


            }
            catch (Exception ex)
            {

                poruka = "An error occurred while sending mail. Please try again later.";
            }
          



            return Json(new { poruka = poruka });
        }

        public void ConfirmBooking(int email, string lang) {
            String emailUser = "";
            try
            {
                using(var dbContext=new DB_9B8AB0_taxiEntities()){

                    var rez = dbContext.Rezervacije.Where(x => x.ID.Equals(email)).SingleOrDefault();
                    rez.IsConfirmed = true;

                    var k = dbContext.Korisnici.Where(x => x.ID.Equals(rez.KorisniciID)).SingleOrDefault();
                    k.BrojVoznje++;
                    k.UkupnoVoznje++;

                    dbContext.SaveChanges();
                    
                    emailUser = rez.Korisnici.Email;                
                
                

                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("007flughafentaxi@gmail.com", "nautilus142");
                // client.Credentials = System.Net.CredentialCache.DefaultCredentials;

                MailMessage mm = new MailMessage("flughafentaxibond@gmail.com", emailUser);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mm.Subject = "Confirm reservation";
                mm.IsBodyHtml = true;

                StringBuilder sb1;


                if (lang.Equals("ger"))
                {
                    StringBuilder sb = new StringBuilder("Sehr geehrter Kunde,<br/><br/>  Ihre Reservierung bestätigt ist , wird der Fahrer zu Ihnen kommen.<br/><br/><br/> Mit freundlichen Grüßen<br/><br/><br/><table border=\"1\"><tbody><tr><td>Pick Up-Date</td><td>");
                    sb.Append(rez.DatumVreme + "</td></tr><tr><td>vom / zum Flughafen</td><td>");
                    sb.Append(rez.FromToAirport + "</td></tr><tr><td>Preis</td><td>");
                    sb.Append(rez.Price + "</td></tr><tr><td>Name</td><td>");
                    sb.Append(rez.Korisnici.Name + "</td></tr><tr><td>Lage</td><td>");
                    sb.Append(rez.Ulice.Oblasti.Gradovi.Name + "</td></tr><tr><td>Plz</td><td>");
                    sb.Append(rez.Ulice.Oblasti.Name + "</td></tr><tr><td>Straße</td><td>");
                    sb.Append(rez.Ulice.Name + "</td></tr><tr><td>Telefon</td><td>");
                    sb.Append(rez.Korisnici.Telefon + "</td></tr><tr><td>E-Mail</td><td>");
                    sb.Append(rez.Korisnici.Email + "</td></tr><tr><td>Fahrzeugtyp</td><td>");
                    sb.Append(rez.CarType + "</td></tr><tr><td>Koffer</td><td>");
                    sb.Append(rez.Suitcases + "</td></tr><tr><td>Bezahlung</td><td>");                                 
                    sb.Append(rez.Payment + "</td></tr></tbody></table><br/><br/>");

                    sb1 = sb;

                   // mm.Body = sb.ToString();
                   
                }
                else
                {
                    StringBuilder sb = new StringBuilder("Dear customer,<br/><br/> your reservation is confirmed, the driver will come to you.<br/><br/><br/> Best regards.<br/><br/><br/><table border=\"1\"><tbody><tr><td>Pick Up-Date</td><td>");
                    sb.Append(rez.DatumVreme + "</td></tr><tr><td>from / to airport</td><td>");
                    sb.Append(rez.FromToAirport + "</td></tr><tr><td>Price</td><td>");
                    sb.Append(rez.Price + "</td></tr><tr><td>Full Name</td><td>");
                    sb.Append(rez.Korisnici.Name + "</td></tr><tr><td>Hand laguage</td><td>");
                    sb.Append(rez.Ulice.Oblasti.Gradovi.Name + "</td></tr><tr><td>Zip Code</td><td>");
                    sb.Append(rez.Ulice.Oblasti.Name + "</td></tr><tr><td>Street</td><td>");
                    sb.Append(rez.Ulice.Name + "</td></tr><tr><td>Phone</td><td>");
                    sb.Append(rez.Korisnici.Telefon + "</td></tr><tr><td>Email</td><td>");
                    sb.Append(rez.Korisnici.Email + "</td></tr><tr><td>Type of Car</td><td>");
                    sb.Append(rez.CarType + "</td></tr><tr><td>Suitcases</td><td>");
                    sb.Append(rez.Suitcases + "</td></tr><tr><td>Payment</td><td>");
                    sb.Append(rez.Payment + "</td></tr></tbody></table><br/><br/>");

                    sb1 = sb;



                    //mm.Body = sb.ToString();
                }
                if (rez.FromToAirport.Equals("from airport"))
                {

                   // string html = @"<html><body><img src=""cid:YourPictureId"" width='300' height='300'></body></html>";
                    sb1.Append(@"<img src=""cid:YourPictureId"" width='600' height='300'>");
                    AlternateView altView = AlternateView.CreateAlternateViewFromString(sb1.ToString(), null, MediaTypeNames.Text.Html);
                   // AlternateView altView1 = AlternateView.CreateAlternateViewFromString(sb1.ToString(), null, MediaTypeNames.Text.Html);
                    string filePath = Server.MapPath(Url.Content("~/Content/pic/Plan.png"));
                    LinkedResource yourPictureRes = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
                    yourPictureRes.ContentId = "YourPictureId";
                    altView.LinkedResources.Add(yourPictureRes);

                    mm.AlternateViews.Add(altView);
                  

                }
                mm.Body = sb1.ToString();
                
                client.Send(mm);

                Response.ClearHeaders();
                Response.ContentType = "text/html";
                // Response.AddHeader("content-disposition", attachment;filename='Test.csv'");
                Response.Write("<h1 style=\"text-align:center\">Rezervacija je potvrdjena.</h1>");
                Response.End();
            }
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


        public ActionResult Cena(String klasa, int zona)
        {
            String cena;
            using (var dbContext =new DB_9B8AB0_taxiEntities()) {

                var oblast = dbContext.Oblasti.Where(x => x.Id.Equals(zona)).FirstOrDefault();
                switch (klasa)
                {
                    case "1": {
                        cena = oblast.Zona1;
                        break;
                    }
                    case "2":{
                        cena = oblast.Zona2;
                        break;
                    }
                    case "3": {
                        cena = oblast.Zona3;
                        break;
                    
                    }
                    default: {
                        cena = "";
                        break;
                    }
                }
            
            
            }

            return Json(new { cena = cena });
        }
        public void CancleBooking(int email)
        {
            String emailUser = "";
            try
            {
                using (var dbContext = new DB_9B8AB0_taxiEntities())
                {

                    var rez = dbContext.Rezervacije.Where(x => x.ID.Equals(email)).SingleOrDefault();              

                    emailUser = rez.Korisnici.Email;


                }

                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("007flughafentaxi@gmail.com", "nautilus142");
                // client.Credentials = System.Net.CredentialCache.DefaultCredentials;

                MailMessage mm = new MailMessage("flughafentaxibond@gmail.com", emailUser);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mm.Subject = "Rejected reservation";
                mm.IsBodyHtml = true;

                //if (!Session["lang"].ToString().Equals("ger"))
                //    mm.Body = "Dear customer,<br/><br/> we are sorry but we don't have enough avaible drivers at this moment.<br/><br/><br/><br/>Best regards";
                //else
                mm.Body = "Dear customer,<br/><br/> we are sorry but we don't have enough avaible drivers at this moment.<br/><br/><br/><br/>Best regards<br/><br/><br/><br/><br/><br/>Sehr geehrter Kunde,<br/><br/> es tut uns leid , aber wir haben nicht genug avaible Fahrer in diesem Moment.<br/><br/><br/><br/> Mit freundlichen Grüßen";
              
                client.Send(mm);

                Response.ClearHeaders();
                Response.ContentType = "text/html";
                // Response.AddHeader("content-disposition", attachment;filename='Test.csv'");
                Response.Write("<h1 style=\"text-align:center\">Otkazano.</h1>");
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

    }


}