using CZE.Data;
using CZE.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZE.Web.Areas.AdministrativniRadnik.Models
{
    public class GrupaEditVM
    {
        public int GrupaID { get; set; }
        [Required(ErrorMessage="Naziv grupe je obavezno polje.")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Datum početka je obavezno polje.")]
        [Display(Name="Datum početka")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Pocetak { get; set; }
        [Display(Name = "Datum završetka")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Kraj { get; set; }
        public bool Aktivna { get; set; }
        [Display(Name = "Kurs")]
        [Required(ErrorMessage = "Kurs je obavezno polje.")]
        public int KursID { get; set; }
        public List<SelectListItem> KursDDL{ get; set; }
        [Display(Name = "Predavač")]
        [Required(ErrorMessage = "Predavač je obavezno polje.")]
        public int ZaposlenikID { get; set; }
        public List<SelectListItem> PredavacDDL { get; set; }


        public GrupaEditVM()
        {
            Aktivna = true;
        }
        public GrupaEditVM(Grupa g)
        {
            this.GrupaID = g.GrupaID;
            this.Naziv = g.Naziv;
            this.Pocetak = g.Pocetak;
            this.Kraj = g.Kraj;
            this.Aktivna = g.Aktivna;
            this.KursID = g.KursID;
            this.ZaposlenikID = g.ZaposlenikID;
        }
        public Grupa ToGrupa()
        {
            Grupa g = new Grupa();
            g.GrupaID = this.GrupaID;
            g.Naziv = this.Naziv;
            g.Pocetak = this.Pocetak;
            g.Kraj = this.Kraj;
            g.Aktivna = this.Aktivna;
            g.KursID = this.KursID;
            g.ZaposlenikID = this.ZaposlenikID;
            return g;
        }
        public static List<SelectListItem> KursDDLSet(CZEContext db, int kursId = 0)
        {
            return db.Kursevi
                .AsNoTracking()
                .Select(s => new SelectListItem {
                Text=s.Naziv+"|"+s.KursTip.Naziv,
                Value=s.KursID.ToString(),
                Selected=s.KursID==kursId
                })
                .ToList();
        }
        public static List<SelectListItem> PredavaciDDLSet(CZEContext db, int predavacId = 0)
        {
            return db.Zaposlenici
                .AsNoTracking()
                .Where(x => x.UgovoriZaposljenja.Any(w => w.Status == true && w.PozicijaKompanije.Naziv == "Predavač"))
                .Select(s => new SelectListItem
                {
                    Text=s.Osoba.Ime+" "+s.Osoba.Prezime,
                    Value=s.ZaposlenikID.ToString(),
                    Selected=s.ZaposlenikID==predavacId
                }).ToList();
        }
    }
}