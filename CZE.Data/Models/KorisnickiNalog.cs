using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CZE.Data.Models
{
    [Table("KorisnickiNalozi")]
    public class KorisnickiNalog
    {
        [Key()]
        [ForeignKey("Osoba")]
        public int KorisnickiNalogID { get; set; }
        public virtual Osoba Osoba { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public bool Aktivan { get; set; }
        public UlogeKorisnika UlogaKorisnika { get; set; }

    }

    public enum UlogeKorisnika { Administrator, Direktor, Administrativni_Radnik, Predavac, Kandidat }
    public static class UlogaKorisnika
    {
        public static SelectList GetUlogeKorisnikaAsSelectList(UlogeKorisnika selectedUlogaKorisnika = UlogeKorisnika.Kandidat)
        {
            IEnumerable<UlogeKorisnika> tipovi = Enum.GetValues(typeof(UlogeKorisnika)).Cast<UlogeKorisnika>();

            return new SelectList(tipovi, selectedUlogaKorisnika);
        }

    }
}
