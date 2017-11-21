using CZE.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZE.Web.Areas.Direktor.Models
{
    public class ObracunskiPeriodVM
    {
        public List<ObracunskiPeriod> oPeriodi { get; set; }

        [Display(Name = "Datum obračuna")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage="Unesite datum.")]
        public DateTime DatumObracuna { get; set; }
        public static List<SelectListItem> ObracunskiPeriodiDDLSet(List<ObracunskiPeriod> obracunskiPeriodi)
        {
            return obracunskiPeriodi.Select(s => new SelectListItem
            {
                Value = s.ObracunskiPeriodID.ToString(),
                Text = s.DatumObracuna.ToString("dd-MM-yyyy"),
            }).ToList();
        }
    }
}