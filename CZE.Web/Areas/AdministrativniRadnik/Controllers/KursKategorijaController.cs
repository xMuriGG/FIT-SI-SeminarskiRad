using CZE.Data;
using CZE.Data.Models;
using CZE.Web.Areas.AdministrativniRadnik.Models;
using CZE.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZE.Web.Areas.AdministrativniRadnik.Controllers
{
    [Autorizacija(UlogeKorisnika.Administrativni_Radnik, UlogeKorisnika.Direktor, UlogeKorisnika.Administrator)]
    public class KursKategorijaController : Controller
    {
        CZEContext db = new CZEContext();

        public ActionResult Main()
        {
            if (TempData["InfoMessage"] != null)
                ViewBag.InfoMessage = TempData["InfoMessage"];
            var k = new KursKategorijaVM();
            k.KursKategorije = db.KursKategorije.AsNoTracking().ToList();
            return View(k);
        }
        public PartialViewResult _Create()
        {
            return PartialView("_Create");
        }
        [HttpPost]
        public ActionResult Create(KursKategorijaVM model)
        {
            if (ModelState.IsValid)
            {
                db.KursKategorije.Add(model.ToKursKategorija());
                try
                {
                    db.SaveChanges();
                    TempData["InfoMessage"] = new InfoMessage("Kategorija kursa '" + model.Naziv + "' uspješno pohranjena u bazu.", InfoMessageType.success);
                    return RedirectToAction("Main");
                }
                catch (Exception)
                {
                }
            }
            TempData["InfoMessage"] = new InfoMessage("Kategorija kursa nije pohranjena u bazu.", InfoMessageType.danger);

            return RedirectToAction("Main");
        }
        public PartialViewResult _Edit(int id)
        {
            KursKategorija kk = db.KursKategorije.Find(id);
            KursKategorijaVM kkVM = new KursKategorijaVM();
            kkVM.KursKategorijaID = kk.KursKategorijaID;
            kkVM.Naziv = kk.Naziv;
            return PartialView("_Edit", kkVM);
        }
        [HttpPost]
        public ActionResult Edit(KursKategorijaVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    KursKategorija kk = model.ToKursKategorija();
                    db.KursKategorije.Attach(kk);
                    db.Entry(kk).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    TempData["InfoMessage"] = new InfoMessage("Kategorija kursa '" + model.Naziv + "' uspješno editovana.", InfoMessageType.success);
                }
                catch (Exception)
                {
                    TempData["InfoMessage"] = new InfoMessage("Kategorija kursa '" + model.Naziv + "' nije editovana.", InfoMessageType.danger);
                }
            }
            else
            {
                TempData["InfoMessage"] = new InfoMessage("Kategorija kursa '" + model.Naziv + "' nije editovana.", InfoMessageType.danger);
            }
            return RedirectToAction("Main");
        }
        public ActionResult Delete(int id)
        {
            if (!db.KursTipovi.Any(x => x.KursKategorijaID == id))
            {
                try
                {
                    KursKategorija k = new KursKategorija { KursKategorijaID = id };
                    db.KursKategorije.Attach(k);
                    db.KursKategorije.Remove(k);
                    db.SaveChanges();
                    TempData["InfoMessage"] = new InfoMessage("Kategorija kursa izbrisana.", InfoMessageType.success);
                    return RedirectToAction("Main");
                }
                catch (Exception)
                {

                }
            }
            TempData["InfoMessage"] = new InfoMessage("Kategoriju kursa nije moguće obrisati.", InfoMessageType.danger);

            return RedirectToAction("Main");
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