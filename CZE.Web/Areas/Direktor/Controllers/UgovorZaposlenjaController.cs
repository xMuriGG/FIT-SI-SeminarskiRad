using CZE.Data;
using CZE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CZE.Web.Areas.Direktor.Models;
using System.IO;
using System.Net;
using CZE.Web.Helper;
using System.Data.Entity.Validation;
namespace CZE.Web.Areas.Direktor.Controllers
{
    [Autorizacija(UlogeKorisnika.Direktor, UlogeKorisnika.Administrator)]
    public class UgovorZaposlenjaController : Controller
    {
        CZEContext db = new CZEContext();
        // GET: Direktor/UgovorZaposlenja
        public ActionResult Create()
        {
            List<PozicijaKompanije> pozicije = db.PozicijeKompanije.ToList();
            List<Zaposlenik> zaposlenici = db.Zaposlenici.ToList();

            return View(new UgovorZaposlenjaCreateVM(pozicije, zaposlenici));
        }
        [HttpPost]
        public ActionResult Create(UgovorZaposlenjaCreateVM model)
        {
            if (ModelState.IsValid)
            {
                model.Status = true;
                try
                {
                    db.Ugovori.Add(model.ToUgovorZaposlenja());
                    db.SaveChanges();
                    return RedirectToAction("PrikazList");
                }
                catch (DbEntityValidationException)
                {

                }
            }

            List<PozicijaKompanije> pozicije = db.PozicijeKompanije.ToList();
            List<Zaposlenik> zaposlenici = db.Zaposlenici.ToList();
            model.PozicijeKompanijeDDL = new SelectList(pozicije, "PozicijaKompanijeID", "Naziv", model.PozicijaKompanijeID);
            model.ZaposleniciDDL = zaposlenici.Select(s => new SelectListItem
            {
                Value = s.ZaposlenikID.ToString(),
                Text = s.Osoba.Ime + " " + s.Osoba.Prezime + " [" + (DateTime.Now.Year - s.Osoba.DatumRodjenja.Year) + "][" + s.BrojRadneKnjizice + "]",
                Selected = s.ZaposlenikID == model.ZaposlenikID
            }).ToList();
            return View(model);
        }

        public ActionResult PrikazList()
        {
            if (TempData["InfoMessage"] != null)
                ViewBag.InfoMessage = TempData["InfoMessage"];
            return View(UgovoriPrikazTable());
        }

        private List<UgovorZaposlenjaDetailsVM> UgovoriPrikazTable()
        {
            List<UgovorZaposlenjaDetailsVM> ugovori = db.Ugovori.Select(s => new UgovorZaposlenjaDetailsVM()
            {
                UgovorZaposlenjaID = s.UgovorZaposlenjaID,
                PozicijaKompanije = s.PozicijaKompanije,
                Zaposlenik = s.Zaposlenik,
                DatumPocetkaUgovora = s.DatumPocetkaUgovora,
                Period = s.Period,
                Prilog=!string.IsNullOrEmpty(s.UgovorFileName),
                Status = s.Status
            }).ToList();

            return ugovori;
        }
        public ActionResult Download(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var anonimus = db.Ugovori.Where(x => x.UgovorZaposlenjaID == id).Select(s => new { s.UgovorFile, s.UgovorFileType, s.UgovorFileName });
            byte[] file = anonimus.Select(s => s.UgovorFile).SingleOrDefault();
            string name = anonimus.Select(s => s.UgovorFileName).SingleOrDefault();
            string type = anonimus.Select(s => s.UgovorFileType).SingleOrDefault();

            if (file == null)
            {
                TempData["InfoMessage"] = new InfoMessage("Ugovor nema prilog.", InfoMessageType.info);             
                return RedirectToAction("PrikazList");
            }

            return File(file, type, name);
        }
        public ActionResult PromjenaStatusaUgovora(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            bool status = db.Ugovori.Where(x => x.UgovorZaposlenjaID == id).Select(s => new { s.Status }).Select(s => s.Status).FirstOrDefault();
            UgovorZaposlenja u = new UgovorZaposlenja();
            u.UgovorZaposlenjaID = (int)id;
            u.Status = status ? false : true;

            db.Ugovori.Attach(u);
            var entry = db.Entry(u);
            entry.Property(p => p.Status).IsModified = true;
            db.SaveChanges();

            return PartialView("_UgoviriPrikazTable", UgovoriPrikazTable());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UgovorZaposlenjaDetailsVM ugovor = db.Ugovori.Where(x => x.UgovorZaposlenjaID == id).Select(s => new UgovorZaposlenjaDetailsVM
            {
                UgovorZaposlenjaID = s.UgovorZaposlenjaID,
                PozicijaKompanije = s.PozicijaKompanije,
                Zaposlenik = s.Zaposlenik,
                UgovorFileName = s.UgovorFileName,
                DatumPocetkaUgovora = s.DatumPocetkaUgovora,
                Koeficijent = s.Koeficijent,
                OpisPosla = s.OpisPosla,
                Period = s.Period,
                Prilog = !string.IsNullOrEmpty(s.UgovorFileName),
                Status = s.Status
            }).FirstOrDefault();

            if (ugovor == null)
            {
                return HttpNotFound();
            }
            return View(ugovor);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                try
                {
                    UgovorZaposlenja u = new UgovorZaposlenja { UgovorZaposlenjaID = id ?? 0 };
                    db.Ugovori.Attach(u);
                    db.Ugovori.Remove(u);
                    db.SaveChanges();
                    TempData["InfoMessage"] = new InfoMessage("Ugovor uspješno obrisan.", InfoMessageType.success);
                    return RedirectToAction("PrikazList");

                }
                catch (Exception)
                {

                }

                TempData["InfoMessage"] = new InfoMessage("Ugovor nije obrisan.", InfoMessageType.danger);
                return RedirectToAction("PrikazList");
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