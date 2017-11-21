using CZE.Data;
using CZE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CZE.Web.Helper;
namespace CZE.Web.Controllers
{
    public class AutentifikacijaController : Controller
    {

        CZEContext db = new CZEContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentificate(string korisnickoIme, string lozinka, string zapamti)
        {
            LogiraniKorisnik lKorisnik = LogiraniKorisnik.LogiraniKorisnikGetByLogInInfoFromDatabase(db,korisnickoIme,lozinka);

            if (lKorisnik == null)
            {
                return RedirectToAction("Index");
            }
            Autentifikacija.PokreniNovuSesiju(lKorisnik, HttpContext, (zapamti == "on"));
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            Autentifikacija.PokreniNovuSesiju(null, HttpContext, true);
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}