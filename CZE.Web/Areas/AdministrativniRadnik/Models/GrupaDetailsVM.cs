using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CZE.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CZE.Web.Areas.AdministrativniRadnik.Models
{
    public class GrupaDetailsVM
    {
        public Kurs Kurs { get; set; }
        public KursTip KursTip { get; set; }

        public int GrupaID { get; set; }
        public string Naziv { get; set; }
        [Display(Name = "Datum početak")]
        [DataType(DataType.Date)]
        public DateTime Pocetak { get; set; }
        [Display(Name = "Datum završetka")]
        [DataType(DataType.Date)]
        public DateTime? Kraj { get; set; }
        public bool Aktivna { get; set; }
        public int KursID { get; set; }
        [Display(Name="Predavač")]
        public int KandidatID { get; set; }
        public string ImePrezimeZaposlenika { get; set; }
    }
}