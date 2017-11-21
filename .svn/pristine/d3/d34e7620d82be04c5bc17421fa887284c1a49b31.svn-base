using CZE.Data;
using CZE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CZE.Web.Helper
{
    public class Autentifikacija
    {
        private const string LogiraniKorisnik = "logirani_korisnik";
        public static void PokreniNovuSesiju(LogiraniKorisnik logiraniKorisnik, HttpContextBase context, bool zapamtiPassword)
        {
            context.Session.Add(LogiraniKorisnik, logiraniKorisnik);

            if (zapamtiPassword)
            {
                HttpCookie cookie = new HttpCookie("_mvc_session", logiraniKorisnik != null ? logiraniKorisnik.KorisnickiNalogID.ToString() : "");
                cookie.Expires = DateTime.Now.AddDays(10);
                context.Response.Cookies.Add(cookie);
            }
        }
        public static LogiraniKorisnik GetLogiraniKorisnik(HttpContextBase context)
        {
            LogiraniKorisnik lKorisnik = (LogiraniKorisnik)context.Session[LogiraniKorisnik];

            if (lKorisnik != null)
                return lKorisnik;

            HttpCookie cookie = context.Request.Cookies.Get("_mvc_session");

            if (cookie == null)
                return null;

            long userId;
            try
            {
                userId = Int64.Parse(cookie.Value);
            }
            catch
            {
                return null;
            }

            using (CZEContext db = new CZEContext())
            {
                LogiraniKorisnik lK = db.KorisnickiNalozi
                 .AsNoTracking()
                 .Select(s => new LogiraniKorisnik
                 {
                     KorisnickiNalogID = s.KorisnickiNalogID,
                     Osoba = s.Osoba,
                     KorisnickoIme = s.KorisnickoIme,
                     Lozinka = s.Lozinka,
                     Aktivan = s.Aktivan,
                     UlogaKorisnika = s.UlogaKorisnika
                 })
                 .FirstOrDefault(x => x.KorisnickiNalogID == userId );
                   
                PokreniNovuSesiju(lK, context, true);
                return lK;
            }
        }
        public static int GetLogiraniKorisnikId(HttpContextBase context)
        {
            return GetLogiraniKorisnik(context).KorisnickiNalogID;
        }
    }
}