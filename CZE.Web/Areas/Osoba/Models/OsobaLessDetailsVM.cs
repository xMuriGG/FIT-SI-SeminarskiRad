using CZE.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CZE.Web.Areas.Osoba.Models
{
    public class OsobaLessDetailsVM
    {
         public int OsobaID { get; set; }
        [Display(Name="Ime i prezime")]
        public string ImePrezime { get; set; }

        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DatumRodjenja { get; set; }
        public Spol Spol { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public bool IsZaposlenik { get; set; }
        public bool IsKandidat { get; set; }
        public  OsobaLessDetailsVM()
        {

        }
        public OsobaLessDetailsVM(Data.Models.Osoba o)
        {
            this.OsobaID = o.OsobaID;
            this.ImePrezime = o.Ime +" "+o.Prezime;
            this.DatumRodjenja = o.DatumRodjenja;
            this.Spol = o.Spol;
            this.Email = o.Email;
            this.Adresa = o.Adresa;
            this.IsKandidat = o.Kandidat != null ? true : false;
            this.IsZaposlenik = o.Zaposlenik != null ? true : false;
        }
    }
}