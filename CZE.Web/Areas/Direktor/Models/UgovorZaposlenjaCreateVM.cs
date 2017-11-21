﻿using CZE.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZE.Web.Areas.Direktor.Models
{
    public class UgovorZaposlenjaCreateVM
    {
        public int UgovorZaposlenjaID { get; set; }
        [Required(ErrorMessage = "Odaberi poziciju.")]
        public int PozicijaKompanijeID { get; set; }
        public SelectList PozicijeKompanijeDDL { get; set; }
        [Required(ErrorMessage = "Odaberi zaposlenika.")]
        public int ZaposlenikID { get; set; }
        public List<SelectListItem> ZaposleniciDDL { get; set; }
        [Required(ErrorMessage = "Unesite datum.")]
        [Display(Name = "Važi od")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatumPocetkaUgovora { get; set; }
        public int? Period { get; set; } // u mjesecima null
        [Required(ErrorMessage = "Koeficijent je obavezno polje")]
        public decimal Koeficijent { get; set; }
        public bool Status { get; set; }
        [DataType(DataType.Upload)]
        public HttpPostedFileBase UploadFile { get; set; }
        [Display(Name = "Opis posla")]
        [DataType(DataType.MultilineText)]
        public string OpisPosla { get; set; }


        public UgovorZaposlenjaCreateVM()
        {

        }
        public UgovorZaposlenjaCreateVM(List<PozicijaKompanije> pozicijeKompanije, List<Zaposlenik> zaposlenici)
        {
            this.PozicijeKompanijeDDL = new SelectList(pozicijeKompanije, "PozicijaKompanijeID", "Naziv");
            this.ZaposleniciDDL = zaposlenici.Select(s => new SelectListItem
            {
                Value = s.ZaposlenikID.ToString(),
                Text = s.Osoba.Ime + " " + s.Osoba.Prezime + " [" + (DateTime.Now.Year - s.Osoba.DatumRodjenja.Year) + "][" + s.BrojRadneKnjizice + "]",
            }).ToList();
        }     
        public UgovorZaposlenja ToUgovorZaposlenja()
        {
            UgovorZaposlenja u = new UgovorZaposlenja();
            u.UgovorZaposlenjaID = this.UgovorZaposlenjaID;
            u.PozicijaKompanijeID = this.PozicijaKompanijeID;
            u.ZaposlenikID = this.ZaposlenikID;
            u.DatumPocetkaUgovora = this.DatumPocetkaUgovora;
            u.Period = this.Period;
            u.Koeficijent = this.Koeficijent;
            u.Status = this.Status;
            if (this.UploadFile != null)
            {
                u.UgovorFile = new byte[UploadFile.InputStream.Length];
                UploadFile.InputStream.Read(u.UgovorFile, 0, UploadFile.ContentLength);
                u.UgovorFileName = this.UploadFile.FileName;
                u.UgovorFileType = this.UploadFile.ContentType;
            }
            u.OpisPosla = this.OpisPosla;
            u.PozicijaKompanije = null;
            u.Zaposlenik = null;
            return u;
        }
    }
}