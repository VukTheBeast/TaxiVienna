using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TaxiWebSite.Models;

namespace TaxiWebSite.Controllers
{
    public class BookingFromController : Controller
    {
        // GET: BookingFrom

        public ActionResult BookingFrom() {
            ViewBag.lang = Session["lang"];
            using (var dbContext = new DB_9B8AB0_taxiEntities())
            {

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
        [HttpPost]
        public ActionResult BookingFromAerodroma(String pickUpDate, String pickUpTime, String flightFromlightFrom, String flightNumber,
                                                String pickUpFrom, String fullName, String location,
                                                String zipCode, String phone, String email, String typeOfCar, String suitcases,
                                                String handLaggage, String payment, String street, String isReturn,
                                                String returnData, String returnTime, String ID_Ulice, String price)
        {

            String poruka = "Vasa rezervacija je poslata vozacu. Proverite mejl da li vam je potvrdjena rezervacija";

            int idRezervacije = 0;
            try
            {
                using (var dbContext = new DB_9B8AB0_taxiEntities())
                {
                    var korisnik = dbContext.Korisnici.Where(x => x.Email.Equals(email)).SingleOrDefault();//proveravam da li imamo korisnika u bazu
                    int idKorisnika;
                    if (korisnik == null)//onda se dodaje u tabelu korisnika i upisuje tabela rezervacija
                    {
                    //    ID_Ulice = "1";//ovo je za test skini posle
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
                    rez.FromToAirport = "from airport";
                    rez.IsConfirmed = false;
                    rez.CarType = typeOfCar;

                    DateTime dt = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
                    rez.DatumVreme = dt;

                    dbContext.Rezervacije.Add(rez);
                    dbContext.SaveChanges();

                    idRezervacije = rez.ID;
                }

            }
            catch (Exception ex)
            {
                //ovde zapamti log
                throw ex;
            }






            // String googleMapsLocation=location+","+zipCode+","+street;
            String googleMapsLocation = "https://www.google.at/maps?q=" + location + "," + street;
            String domain = System.Configuration.ConfigurationManager.AppSettings["domain"].ToString();
            String confirmString = domain + "/Booking/ConfirmBooking?email=" +idRezervacije;
            String cancleBooking = domain + "/Booking/CancleBooking?email=" + idRezervacije;



            StringBuilder sb = new StringBuilder("<table border=\"1\"><tbody><tr><td>Pick Up-Date</td><td>");
            sb.Append(pickUpDate+"   "+pickUpTime + "</td></tr><tr><td>Pick Up-From</td><td>");
            sb.Append(pickUpFrom + "</td></tr><tr><td>Flight From</td><td>");
            sb.Append(flightFromlightFrom + "</td></tr><tr><td>Full Name</td><td>");
            sb.Append(fullName + "</td></tr><tr><td>Location</td><td>");
            sb.Append(location + "</td></tr><tr><td>Zip Code</td><td>");
            sb.Append(zipCode + "</td></tr><tr><td>Street</td><td>");
            sb.Append(street + "</td></tr><tr><td>Cancle Booking</td><td><a href=\"");
            sb.Append(cancleBooking + "\">Cancle Booking</a></td></tr><tr><td>Flight Number</td><td>");
            sb.Append(flightNumber + "</td></tr><tr><td>Phone</td><td>");
            sb.Append(phone + "</td></tr><tr><td>Email</td><td><a href=\"mailto:" + email + "\">");
            sb.Append(email + "</a></td></tr><tr><td>Type of Car</td><td>");
            sb.Append(typeOfCar + "</td></tr><tr><td>Suitcases</td><td>");
            sb.Append(suitcases + "</td></tr><tr><td>Handlaggage</td><td>");
            sb.Append(handLaggage + "</td></tr><tr><td>Comment</td><td>");
            //sb.Append(comment + "</td></tr><tr><td>Payment</td><td>");
            sb.Append(payment + "</td></tr><tr><td>See location</td><td><a href=\"");
            sb.Append(googleMapsLocation + "\">See Location</a></td></tr><tr><td>Confirm</td><td><a href=\"");
            sb.Append(confirmString + "\">Confirm</a></td></tr></tbody></table><br/><br/>");

            if (!isReturn.Equals("false"))
            {
                sb.Append("<br/><br/><table border=\"1\"><tbody><tr><td>Return Date</td><td>");
                sb.Append(returnData + "</td></tr><tr><td>Return Time</td><td>");
                sb.Append(returnTime + "</td></tr></tbody></table>");

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
                client.Credentials = new System.Net.NetworkCredential("flughafentaxibond@gmail.com", "nautilus142");
                // client.Credentials = System.Net.CredentialCache.DefaultCredentials;

                MailMessage mm = new MailMessage(email, "flughafentaxibond@gmail.com");
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mm.Subject = fullName + "[From Airport]";
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
    }
}