using CZE.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CZE.Web.Areas.Direktor.Models
{
    public class UgovorZaposlenjaDetailsVM
    {
        public int UgovorZaposlenjaID { get; set; }
        [Display(Name="Pozicija")]
        public  PozicijaKompanije PozicijaKompanije { get; set; }
        public  Zaposlenik Zaposlenik { get; set; }
        public string UgovorFileName { get; set; }
        [Display(Name = "Važi od")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatumPocetkaUgovora { get; set; }
        public int? Period { get; set; } 
        public decimal Koeficijent { get; set; }
        public bool Prilog { get; set; }
        public bool Status { get; set; }
        [Display(Name = "Opis posla")]
        public string OpisPosla { get; set; }
    }
}