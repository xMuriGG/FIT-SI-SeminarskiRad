using CZE.Data;
using CZE.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CZE.Web.Areas.Direktor.Models
{
    public class PlatnaListaUnosVM
    {
        public List<PlatnaListaUnosTableVM> Zaposlenici { get; set; }
        public List<SelectListItem> ObracunskiPeriodDLL { get; set; }
        [Required(ErrorMessage = "Efektivni sati su obavezno polje.")]
        [Range(1, 100000.00, ErrorMessage = "Efektivni sati nisu realni.")]

        public int EfektivniSati { get; set; }
        [Required(ErrorMessage = "Obračunski period je obavezno polje.")]
        public int ObracunskiPeriod { get; set; }
        [Required(ErrorMessage = "Svrha je obavezno polje.")]
        [DataType(DataType.MultilineText)]
        public string Svrha { get; set; }
        [Required(ErrorMessage = "Količina je obavezno polje.")]
        [DataType(DataType.Currency)]
        [Range(1, 100000.00, ErrorMessage = "Količina nije realna.")]
        public decimal IznosPlate { get; set; } //Koeficijent * EfektivniSati

        public PlatnaListaUnosVM()
        {

        }
        public PlatnaListaUnosVM(CZEContext db, List<ObracunskiPeriod> obracunskiPeriodi)
        {
            Zaposlenici = db.Osobe.Where(x => x.Zaposlenik.ZaposlenikID == x.OsobaID).Select(s => new PlatnaListaUnosTableVM
            {
                OsobaID = s.OsobaID,
                ImePrezime = s.Ime + " " + s.Prezime,
                DatumRodjenja = s.DatumRodjenja,
                Spol = s.Spol,
                Pozicija = s.Zaposlenik.UgovoriZaposljenja.Where(x => x.Status).Select(x => x.PozicijaKompanije.Naziv).FirstOrDefault(),
                Selected = false
            }).ToList();

            ObracunskiPeriodDLL = ObracunskiPeriodVM.ObracunskiPeriodiDDLSet(obracunskiPeriodi);
        }

    }
}
