using CZE.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZE.Web.Areas.AdministrativniRadnik.Models
{
    public class KursVM
    {
        public int KursID { get; set; }
        public int KursTipID { get; set; }
        public List<SelectListItem> KursTipoviDDL { get; set; }
        [Required(ErrorMessage = "Naziv kursa je obavezno polje.")]
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public KursVM() { }
        public KursVM(List<KursTip> kursTipovi,int kursTipId)
        {
            KursTipoviDDL = KursTipoviDDLSet(kursTipovi,kursTipId);
        }
        public KursVM(Kurs k, List<KursTip> kursTipovi)
        {
            KursID = k.KursID;
            KursTipID = k.KursTipID;
            KursTipoviDDL = KursTipoviDDLSet(kursTipovi, k.KursTipID);
            Naziv = k.Naziv;
            Opis = k.Opis;
        }
        public static List<SelectListItem> KursTipoviDDLSet (List<KursTip> kursTipovi,int kursTipId=0)
        {
            return kursTipovi.Select(s => new SelectListItem
            {
                Value = s.KursTipID.ToString(),
                Text = s.Naziv + " | " + s.KursKategorija.Naziv,
                Selected = kursTipId == s.KursTipID
            }).ToList();
        }
        public Kurs ToKurs()
        {
            Kurs k = new Kurs();
            k.KursID = this.KursID;
            k.KursTipID = this.KursTipID;        
            k.Naziv = this.Naziv;
            k.Opis = this.Opis;
            return k;
        }

    }
}