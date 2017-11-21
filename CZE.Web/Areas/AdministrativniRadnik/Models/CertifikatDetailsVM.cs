using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CZE.Web.Areas.Osoba.Models;
namespace CZE.Web.Areas.AdministrativniRadnik.Models
{
    public class CertifikatDetailsVM
    {
        public GrupaDetailsVM GrupaKursTipDetails { get; set; }
        public OsobaDetailsVM OsobaDetails { get; set; }
        public int CertifikatId { get; set; }
        [Display(Name = "Datum odobrenja")]
        [DataType(DataType.Date)]
        public DateTime DatumOdobrenja { get; set; }
        [Display(Name = "Uručeno")]
        public bool Uruceno { get; set; }
        public string Biljeske { get; set; }
        [Display(Name="Odobrio")]
        public string ZaposlenikOdobrio { get; set; }
    }
}