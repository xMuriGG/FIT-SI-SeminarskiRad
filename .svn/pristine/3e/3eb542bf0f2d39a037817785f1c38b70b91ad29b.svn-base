using CZE.Data;
using CZE.Data.Models;
using CZE.Web.Areas.AdministratorSistema.Models;
using CZE.Web.Areas.Osoba.Models;
using CZE.Web.Helper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZE.Web.Areas.AdministratorSistema.Controllers
{
    public class KorisnickiNalogController : Controller
    {
        CZEContext db = new CZEContext();
        // GET: AdministratorSistema/KorisnickiNalog
        public ActionResult Prikazi()
        {
            if (TempData["InfoMessage"] != null)
                ViewBag.InfoMessage = TempData["InfoMessage"];
            List<Data.Models.Osoba> osobe = db.Osobe.Where(x => x.KorisnickiNalog == null && (x.Kandidat != null || x.Zaposlenik != null)).ToList();
            List<OsobaLessDetailsVM> less = osobe.Select(s => new OsobaLessDetailsVM(s)).ToList();
            return View(less);
        }
        public ActionResult Create(int id)
        {
            KorisnickiNalogEditVM nalog = new KorisnickiNalogEditVM();
            nalog.KorisnickiNalogID = id;
            return View(nalog);
        }
        [HttpPost]
        public ActionResult Create(KorisnickiNalogEditVM model, bool poruka)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                model.Aktivan = true;
                db.KorisnickiNalozi.Add(model.ToKorisnickiNalog());
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View(model);
            }
            if (poruka)
            {
                string responseMessage="";
                List<string> brojevi = db.BrojeviTelefona
                    .AsNoTracking()
                    .Where(x => x.OsobaID == model.KorisnickiNalogID && x.TipTelefona.ToString() == "Mobilni")
                    .Select(s => s.Broj)
                    .ToList();
                string imePrezime = db.Osobe.AsNoTracking().Where(x => x.OsobaID == model.KorisnickiNalogID).Select(s => s.Ime + " " + s.Prezime).FirstOrDefault();
                foreach (string broj in brojevi)
                {
                    IRestResponse response = Notifications.KandidatUspjesnaRegistracija(imePrezime,model.KorisnickoIme, model.Lozinka, broj);
                    responseMessage +="Response status:"+ response.ResponseStatus.ToString() 
                        +" | StatusCode:"+response.StatusCode.ToString()+ "\n";
                }
                TempData["InfoMessage"] = new InfoMessage(responseMessage, InfoMessageType.info);
            }

            return RedirectToAction("Prikazi");
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