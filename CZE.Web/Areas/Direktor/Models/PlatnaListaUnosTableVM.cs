using CZE.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CZE.Web.Areas.Direktor.Models
{
    public class PlatnaListaUnosTableVM
    {
        public int OsobaID { get; set; }
        [Display(Name = "Ime i prezime")]
        public string ImePrezime { get; set; }
        [Display(Name = "Datum rođenja")]
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }
        public Spol Spol { get; set; }
        public string Pozicija { get; set; }
        public bool Selected { get; set; }

    }
}
