using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace CZE.Web.Areas.AdministrativniRadnik.Models
{
    public class UplataKandidataTableVM
    {
        public int KandidatID { get; set; }
        [Display(Name = "Ime i prezime")]
        public string ImePrezime { get; set; }
        public string Email { get; set; }
        [Display(Name = "Datum rođenja")]
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumUpisa { get; set; }

        public UplataKandidataTableVM(){ }
        public UplataKandidataTableVM(Data.Models.Kandidat kandidat) 
        {
            this.KandidatID = kandidat.KandidatID;
            this.ImePrezime = kandidat.Osoba.Ime +" "+ kandidat.Osoba.Prezime;
            this.Email = kandidat.Osoba.Email;
            this.DatumRodjenja = kandidat.Osoba.DatumRodjenja;
            this.DatumUpisa = kandidat.DatumUpisa;
        }

    }
}