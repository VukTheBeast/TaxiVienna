//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaxiWebSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Korisnici
    {
        public Korisnici()
        {
            this.Rezervacije = new HashSet<Rezervacije>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int ID_Grada { get; set; }
        public int UliceId { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public int UkupnoVoznje { get; set; }
        public int BrojVoznje { get; set; }
    
        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
        public virtual Ulice Ulice { get; set; }
    }
}
