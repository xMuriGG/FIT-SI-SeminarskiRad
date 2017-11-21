using CZE.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace CZE.Web.Areas.AdministrativniRadnik.Models
{
    public class KursTipVM
    {
        public int KursTipID { get; set; }
        [Required(ErrorMessage = "Naziv tipa kursa je obavezno polje.")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Trajanje tipa kursa je obavezno polje.")]
        [Range(1, int.MaxValue, ErrorMessage = "Trajanje tipa kursa je obavezno polje.")]
        public int Trajanje { get; set; }//u casovima
        [Required(ErrorMessage = "Cijena tipa kursa je obavezno polje.")]
        [DataType(DataType.Currency)]
        public decimal Cijena { get; set; }
        [Required(ErrorMessage = "Opis tipa kursa je obavezno polje.")]
        [DataType(DataType.MultilineText)]
        [StringLength(1000, ErrorMessage = "Max. 1000 karaktera.")]
        public string Opis { get; set; }
        [Display(Name = "Kategorija")]
        [Required(ErrorMessage = "Kategorija tipa kursa je obavezno polje.")]
        public int KursKategorijaID { get; set; }
        public List<SelectListItem> KursKategorijeDDL { get; set; }

        public KursTip ToKursTip()
        {
            return new KursTip()
            {
                KursTipID = this.KursTipID,
                Naziv = this.Naziv,
                Trajanje=this.Trajanje,
                Cijena=this.Cijena,
                Opis=this.Opis,
                KursKategorijaID=this.KursKategorijaID
            };
        }

        public KursTipVM(){}
        public KursTipVM(KursTip kursTip,List<KursKategorija> kursKategorije)
        { 
                KursTipID = kursTip.KursTipID;
                Naziv = kursTip.Naziv;
                Trajanje=kursTip.Trajanje;
                Cijena=kursTip.Cijena;
                Opis=kursTip.Opis;
                KursKategorijaID = kursTip.KursKategorijaID;
                KursKategorijeDDL = KursKategorijaVM.KursKategorijeDDLSet(kursKategorije, KursKategorijaID);
        }
    }
}