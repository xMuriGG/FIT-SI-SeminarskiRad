using CZE.Data;
using CZE.Data.Models;
using CZE.Web.Areas.AdministrativniRadnik.Models;
using CZE.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CZE.Web.Areas.AdministrativniRadnik.Controllers
{
    [Autorizacija(UlogeKorisnika.Administrativni_Radnik, UlogeKorisnika.Direktor, UlogeKorisnika.Administrator)]
    public class GrupaController : Controller
    {
        CZEContext db = new CZEContext();
        public ActionResult Create(int kursId = 0)
        {
            GrupaEditVM grupaVM = new GrupaEditVM();
            grupaVM.KursDDL = GrupaEditVM.KursDDLSet(db, kursId);
            grupaVM.PredavacDDL = GrupaEditVM.PredavaciDDLSet(db);
            grupaVM.KursID = kursId;
            grupaVM.Pocetak = DateTime.Now;
            return View(grupaVM);
        }
        [HttpPost]
        public ActionResult Create(GrupaEditVM model)
        {
            if (!ModelState.IsValid)
            {
                model.KursDDL = GrupaEditVM.KursDDLSet(db, model.KursID);
                model.PredavacDDL = GrupaEditVM.PredavaciDDLSet(db, model.ZaposlenikID);
                return View(model);
            }
            try
            {
                db.Grupe.Add(model.ToGrupa());
                db.SaveChanges();

            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Došlo je do greške prilikom validacije, provjeriti unesena polja.");
                model.KursDDL = GrupaEditVM.KursDDLSet(db, model.KursID);
                model.PredavacDDL = GrupaEditVM.PredavaciDDLSet(db, model.ZaposlenikID);
                return View(model);
            }
            TempData["InfoMessage"] = new InfoMessage("Grupa '" + model.Naziv + "' uspješno pohranjena u bazu.", InfoMessageType.success);

            return RedirectToAction("Prikaz", new { kursId = model.KursID });
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupa k = db.Grupe.Find(id);
            if (k == null)
            {
                return HttpNotFound();
            }
            GrupaEditVM gVM = new GrupaEditVM(k);
            gVM.KursDDL = GrupaEditVM.KursDDLSet(db, gVM.KursID);
            gVM.PredavacDDL = GrupaEditVM.PredavaciDDLSet(db, gVM.ZaposlenikID);

            return View(gVM);
        }
        [HttpPost]
        public ActionResult Edit(GrupaEditVM model)
        {
            if (!ModelState.IsValid)
            {
                model.KursDDL = GrupaEditVM.KursDDLSet(db, model.KursID);
                model.PredavacDDL = GrupaEditVM.PredavaciDDLSet(db, model.ZaposlenikID);
                return View(model);
            }
            try
            {
                Grupa grupa = model.ToGrupa();
                db.Grupe.Attach(grupa);
                db.Entry(grupa).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Došlo je do greške prilikom validacije, provjeriti unesena polja.");
                model.KursDDL = GrupaEditVM.KursDDLSet(db, model.KursID);
                model.PredavacDDL = GrupaEditVM.PredavaciDDLSet(db, model.ZaposlenikID);
                return View(model);
            }
            TempData["InfoMessage"] = new InfoMessage("Grupa '" + model.Naziv + "' uspješno editovana.", InfoMessageType.success);

            return RedirectToAction("Prikaz", new { kursId = model.KursID });
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupaDetailsVM details;
            details = db.Grupe
                .AsNoTracking()
                .Where(x => x.GrupaID == id)
                .Select(s => new GrupaDetailsVM
                {
                    Kurs = s.Kurs,
                    KursTip = s.Kurs.KursTip,
                    GrupaID = s.GrupaID,
                    Naziv = s.Naziv,
                    Pocetak = s.Pocetak,
                    Kraj = s.Kraj,
                    Aktivna = s.Aktivna,
                    KursID = s.KursID,
                    ImePrezimeZaposlenika = s.Zaposlenik.Osoba.Ime + " " + s.Zaposlenik.Osoba.Prezime
                })
                .FirstOrDefault();

            return View(details);
        }
        public ActionResult Prikaz(int? kursId)
        {
            if (kursId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (TempData["InfoMessage"] != null)
                ViewBag.InfoMessage = TempData["InfoMessage"];

            List<GrupaTableVM> list = db.Grupe
                .AsNoTracking()
                .Where(x => x.KursID == kursId)
                .Select(s => new GrupaTableVM
                {
                    GrupaID = s.GrupaID,
                    Naziv = s.Naziv,
                    Pocetak = s.Pocetak,
                    Kraj = s.Kraj,
                    Aktivna = s.Aktivna,
                    KursID = s.KursID
                })
                .ToList()
                .OrderByDescending(x => x.GrupaID)
                .ToList();

            ViewBag.kursId = kursId;
            var i = db.Kursevi
                .AsNoTracking()
                .Where(x => x.KursID == kursId)
                .Select(s => new { info = s.Naziv + "-" + s.KursTip.Naziv })
                .FirstOrDefault();
            ViewBag.kursInfo = i.info.ToString();
            return PartialView("_Prikaz", list);
        }
        public ActionResult StatusChange(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupa k = db.Grupe.Find(id);
            if (k == null)
            {
                return HttpNotFound();
            }
            k.Aktivna = k.Aktivna ? false : true;
            try
            {
                db.SaveChanges();
            }
            catch (Exception) { }
            return RedirectToAction("Prikaz", new { kursId = k.KursID });
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupa g = db.Grupe.Find(id ?? 0);
            if (g == null)
            {
                return HttpNotFound();
            }
            int kursId = g.KursID;
            if (!g.GrupaKandidati.Any())
            {
                try
                {
                    db.Grupe.Remove(g);
                    db.SaveChanges();
                    TempData["InfoMessage"] = new InfoMessage("Grupa '" + g.Naziv + "' je obrisana.", InfoMessageType.success);
                    return RedirectToAction("Prikaz", new { kursId = kursId });
                }
                catch (Exception)
                {

                }
            }
            TempData["InfoMessage"] = new InfoMessage("Grupu '" + g.Naziv + "' nije moguće obrisati.", InfoMessageType.danger);

            return RedirectToAction("Prikaz", new { kursId = kursId });
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