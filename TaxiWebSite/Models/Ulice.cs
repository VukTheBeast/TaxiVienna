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
    
    public partial class Ulice
    {
        public Ulice()
        {
            this.Korisnici = new HashSet<Korisnici>();
            this.Rezervacije = new HashSet<Rezervacije>();
        }
    
        public int Id { get; set; }
        public int Id_Oblasti { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Korisnici> Korisnici { get; set; }
        public virtual Oblasti Oblasti { get; set; }
        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
    }
}
