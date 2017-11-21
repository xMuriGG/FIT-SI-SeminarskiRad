using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CZE.Web.Areas.AdministrativniRadnik.Models
{
    public class GrupaTableVM
    {      
        public int GrupaID { get; set; }
        public string Naziv { get; set; }
        [Display(Name = "Početak")]
        [DataType(DataType.Date)]
        public DateTime Pocetak { get; set; }
        [Display(Name = "Kraj")]
        [DataType(DataType.Date)]
        public DateTime? Kraj { get; set; }
        public bool Aktivna { get; set; }
        public int KursID { get; set; }


    }
}