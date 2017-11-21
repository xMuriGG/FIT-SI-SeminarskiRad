using CZE.Data;
using CZE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CZE.Web.Helper
{
    public class LogiraniKorisnik
    {
        public int KorisnickiNalogID { get; set; }
        public Osoba Osoba { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public bool Aktivan { get; set; }
        public UlogeKorisnika UlogaKorisnika { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Spol Spol { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }

        public static LogiraniKorisnik LogiraniKorisnikGetByIdFromDatabase(CZEContext db, int korisnikId)
        {
            return db.KorisnickiNalozi
                 .AsNoTracking()
                 .Select(s => new LogiraniKorisnik
                 {
                     KorisnickiNalogID = s.KorisnickiNalogID,
                     KorisnickoIme = s.KorisnickoIme,
                     Ime = s.Osoba.Ime,
                     Prezime = s.Osoba.Prezime,
                     DatumRodjenja = s.Osoba.DatumRodjenja,
                     Spol = s.Osoba.Spol,
                     Email = s.Osoba.Email,
                     Adresa = s.Osoba.Adresa,
                     Lozinka = s.Lozinka,
                     Aktivan = s.Aktivan,
                     UlogaKorisnika = s.UlogaKorisnika
                 })
                 .FirstOrDefault(x => x.KorisnickiNalogID == 1);
        }
        public static LogiraniKorisnik LogiraniKorisnikGetByLogInInfoFromDatabase(CZEContext db, string korisnickoIme, string lozinka)
        {
            return db.KorisnickiNalozi
                 .AsNoTracking()
                 .Where(x => x.Aktivan
                     && ((x.KorisnickoIme == korisnickoIme || x.Osoba.Email == korisnickoIme)
                     && x.Lozinka == lozinka))
                 .Select(s => new LogiraniKorisnik
                 {
                     KorisnickiNalogID = s.KorisnickiNalogID,
                     KorisnickoIme = s.KorisnickoIme,
                     Ime = s.Osoba.Ime,
                     Prezime = s.Osoba.Prezime,
                     DatumRodjenja = s.Osoba.DatumRodjenja,
                     Spol = s.Osoba.Spol,
                     Email = s.Osoba.Email,
                     Adresa = s.Osoba.Adresa,
                     Lozinka = s.Lozinka,
                     Aktivan = s.Aktivan,
                     UlogaKorisnika = s.UlogaKorisnika
                 })
                 .FirstOrDefault();            
        }
        public bool OdgovaraUlozi(params UlogeKorisnika[] uloge)
        {
            foreach (UlogeKorisnika u in uloge)
            {
                if (this.UlogaKorisnika==u)
                {
                    return true;
                }
            }
            return false;
        }
    }
}