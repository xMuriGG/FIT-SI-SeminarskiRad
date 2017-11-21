using CZE.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CZE.Web.Areas.AdministratorSistema.Models
{
    public class KorisnickiNalogEditVM
    {
        public int KorisnickiNalogID { get; set; }
        [Required(ErrorMessage="Korisničko ime je obavezno polje.")]
        [Display(Name = "Korisničko ime")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezno polje.")]
        public string Lozinka { get; set; }
        [Required(ErrorMessage = "Uloga je obavezno polje.")]
        [Display(Name="Uloga korisnika")]
        public UlogeKorisnika UlogaKorisnika { get; set; }
        public bool Aktivan { get; set; }
        public KorisnickiNalog ToKorisnickiNalog()
        {
            KorisnickiNalog k=new KorisnickiNalog();
            k.KorisnickiNalogID=this.KorisnickiNalogID;
            k.KorisnickoIme=this.KorisnickoIme;
            k.Lozinka=this.Lozinka;
            k.Aktivan=this.Aktivan;
            k.UlogaKorisnika=this.UlogaKorisnika;
            return k;
        }
    }
}