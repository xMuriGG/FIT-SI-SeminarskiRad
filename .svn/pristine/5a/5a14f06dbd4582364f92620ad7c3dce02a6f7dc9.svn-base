using CZE.Data;
using CZE.Data.Models;
using CZE.Web.Areas.Direktor.Models;
using CZE.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZE.Web.Areas.Direktor.Controllers
{
    [Autorizacija(UlogeKorisnika.Direktor, UlogeKorisnika.Administrator)]

    public class ObracunskiPeriodController : Controller
    {
        CZEContext db = new CZEContext();
        public ActionResult ObracunskiPeriodCreate()
        {
            ObracunskiPeriodVM oPeriodVM = new ObracunskiPeriodVM();
            oPeriodVM.oPeriodi = db.ObracunskiPeriodi.OrderByDescending(x => x.ObracunskiPeriodID).ToList();

            if (TempData["InfoMessage"] != null)
                ViewBag.InfoMessage = TempData["InfoMessage"];
            return View(oPeriodVM);
        }
        [HttpPost]
        public ActionResult ObracunskiPeriodCreate(ObracunskiPeriodVM model)
        {
            if (!ModelState.IsValid)
            {
                model.oPeriodi = db.ObracunskiPeriodi.OrderByDescending(x => x.DatumObracuna).ToList();
                return View(model);
            }
            try
            {
                db.ObracunskiPeriodi.Add(new ObracunskiPeriod { DatumObracuna = model.DatumObracuna });
                db.SaveChanges();
                TempData["InfoMessage"] = new InfoMessage("Obračunski period uspješno pohranjen u bazu.", InfoMessageType.success);

            }
            catch (Exception)
            {
                TempData["InfoMessage"] = new InfoMessage("Obračunski period nije pohranjen u bazu.", InfoMessageType.danger);
            }
                return RedirectToAction("ObracunskiPeriodCreate");
        }
        public ActionResult Delete(int id)
        {
            if (!db.PlatneListe.Any(x => x.ObracunskiPeriodID == id))
            {
                try
                {
                    ObracunskiPeriod o = new ObracunskiPeriod { ObracunskiPeriodID = id };
                    db.ObracunskiPeriodi.Attach(o);
                    db.ObracunskiPeriodi.Remove(o);
                    db.SaveChanges();
                    TempData["InfoMessage"] = new InfoMessage("Obračunski period obrisan.", InfoMessageType.success);
                    return RedirectToAction("ObracunskiPeriodCreate");
                }
                catch (Exception)
                {

                }
            }
            TempData["InfoMessage"] = new InfoMessage("Obračunski period nije moguće obrisati.", InfoMessageType.danger);
            return RedirectToAction("ObracunskiPeriodCreate");
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