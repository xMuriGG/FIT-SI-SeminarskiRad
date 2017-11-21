using CZE.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZE.Web.Areas.Osoba.Models
{
    public class OsobaCreateVM
    {
        public int OsobaID { get; set; }
        [Required(ErrorMessage = "Ime je obavezno polje")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno polje")]
        public string Prezime { get; set; }
        [Display(Name = "Datum rođenja")]
        [Required(ErrorMessage = "Unesite datum rođenja ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatumRodjenja { get; set; }
        public Spol Spol { get; set; }
        [Required(ErrorMessage = "Email je obavezno polje")]
        [EmailAddress(ErrorMessage = "Unesi validan Email")]
        public string Email { get; set; }
        [Display(Name = "Adresa stanovanja")]
        [Required(ErrorMessage = "Adresa stanovanja je obavezno polje")]
        public string Adresa { get; set; }
        [Display(Name = "Mjesto rođenja")]
        public int GradID { get; set; }
        public List<BrojTelefonaVM> BrojeviTelefona { get; set; }


        public SelectList GradoviDDL { get; set; }
        [Display(Name = "Brojevi telefona")]
        public SelectList TipoviTelefona
        {
            get
            {
                return TipTelefona.GetTipoveTelefona(TipTelefona.TipoviTelefona.Mobilni);
            }
        }


         public OsobaCreateVM()
        {
            BrojeviTelefona = new List<BrojTelefonaVM>();
            BrojeviTelefona.Add(new BrojTelefonaVM { Broj = "", OsobaID = 0 });
        }
         public OsobaCreateVM(Data.Models.Osoba o)
         {
             this.OsobaID = o.OsobaID;
             this.Ime = o.Ime;
             this.Prezime = o.Prezime;
             this.DatumRodjenja = o.DatumRodjenja;
             this.Spol = o.Spol;
             this.Email = o.Email;
             this.Adresa = o.Adresa;
             this.GradID = o.GradID;
             this.BrojeviTelefona = o.BrojeviTelefona.Select(s => new BrojTelefonaVM
             {
                 Broj = s.Broj,
                 BrojTelefonaID = s.BrojTelefonaID,
                 OsobaID = s.OsobaID,
                 TipTelefona=s.TipTelefona,              
             }).ToList();
         }

        public  Data.Models.Osoba ToOsoba()
        {
           Data.Models.Osoba o = new Data.Models.Osoba();
           o.OsobaID = this.OsobaID;
           o.Ime = this.Ime;
           o.Prezime = this.Prezime;
           o.DatumRodjenja = this.DatumRodjenja;
           o.Spol = this.Spol;
           o.Email = this.Email;
           o.Adresa = this.Adresa;
           o.GradID = this.GradID;
           o.BrojeviTelefona = this.BrojeviTelefona != null ? this.BrojeviTelefona.Select(s => new BrojTelefona
           {
               Broj = s.Broj,
               BrojTelefonaID = s.BrojTelefonaID,
               OsobaID = s.OsobaID,
               TipTelefona = s.TipTelefona
           }).ToList()
           : null;

           return o;
        }
    }
}