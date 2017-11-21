﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CZE.Data.Models;
using CZE.Data;
using System.ComponentModel.DataAnnotations;
namespace CZE.Web.Areas.AdministrativniRadnik.Models
{
    public class UplataKandidataEditVM
    {
        public int UplataKandidataID { get; set; }
        public int NavGrupaKandidatiID { get; set; }
        public int GrupaKandidatiID { get; set; }
        public List<SelectListItem> GrupaKandidatiDDL { get; set; }

        [Required(ErrorMessage="Količina je obavezno polje.")]
        public decimal Kolicina { get; set; }
        [Required()]
        public bool StatusUplate { get; set; }
        [Required()]
        [Display(Name="Račun izdat")]
        public bool RacunIzdat { get; set; }
        [DataType(DataType.MultilineText)]
        public string Biljeske { get; set; }
        [Required(ErrorMessage = "Datum uplate je obavezno polje.")]
        [Display(Name = "Datum uplate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatumUplate { get; set; }

        public static List<SelectListItem> GrupaKandidatiDDLSet(CZEContext db, int grupaKandidatiId)
        {
            int kandidatID = db.GrupeKandidati.AsNoTracking().Where(x => x.GrupaKandidatiID == grupaKandidatiId).FirstOrDefault().KandidatID;
            return db.GrupeKandidati
                .AsNoTracking()
                .Where(x=>x.KandidatID==kandidatID)
                .Select(s => new SelectListItem {
            Text=s.Grupa.Naziv+" | "+s.Grupa.Kurs.Naziv+"|"+s.Grupa.Kurs.KursTip.Naziv,
            Value=s.GrupaKandidatiID.ToString(),
            Selected=s.GrupaKandidatiID==grupaKandidatiId
            }).ToList();
        }

        public UplataKandidata ToUplataKandidata()
        {
            UplataKandidata u=new UplataKandidata();
            u.UplataKandidataID = this.UplataKandidataID;
            u.GrupaKandidatiID = this.GrupaKandidatiID;
            u.Kolicina = this.Kolicina;
            u.StatusUplate = this.StatusUplate;
            u.RacunIzdat = this.RacunIzdat;
            u.Biljeske = this.Biljeske;
            u.DatumUplate = this.DatumUplate;
            return u;
        }
    }
}