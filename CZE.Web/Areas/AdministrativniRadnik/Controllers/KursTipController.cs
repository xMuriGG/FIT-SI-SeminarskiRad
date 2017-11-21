﻿using CZE.Data;
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

    public class KursTipController : Controller
    {
        CZEContext db = new CZEContext();

        public ActionResult KursTipCreate(int kursKategorijaID = 0)
        {
            KursTipVM kt = new KursTipVM();
            kt.KursKategorijeDDL = KursKategorijaVM.KursKategorijeDDLSet(db.KursKategorije.ToList(), kursKategorijaID);
            return View(kt);
        }
        [HttpPost]
        public ActionResult KursTipCreate(KursTipVM model)
        {
            if (ModelState.IsValid)
            {
                db.KursTipovi.Add(model.ToKursTip());
                try
                {
                    db.SaveChanges();
                    TempData["InfoMessage"] = new InfoMessage("Tip kursa '" + model.Naziv + "' uspješno pohranjen u bazu.", InfoMessageType.success);
                }
                catch (Exception)
                {
                    TempData["InfoMessage"] = new InfoMessage("Tip kursa '" + model.Naziv + "' nije pohranjen u bazu.", InfoMessageType.danger);
                }
            }
            else
            {
                model.KursKategorijeDDL = KursKategorijaVM.KursKategorijeDDLSet(db.KursKategorije.ToList(), model.KursKategorijaID);
                return View(model);
            }
            return RedirectToAction("KursTipPrikaz");
        }

        public ActionResult KursTipEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KursTip kt = db.KursTipovi.FirstOrDefault(x => x.KursTipID == id);
            if (kt == null)
            {
                return HttpNotFound();
            }
            List<KursKategorija> kursKategorije = db.KursKategorije.ToList();
            KursTipVM ktVM = new KursTipVM(kt, kursKategorije);

            return View(ktVM);
        }
        [HttpPost]
        public ActionResult KursTipEdit(KursTipVM model)
        {
            if (ModelState.IsValid)
            {
                KursTip edited = model.ToKursTip();
                db.KursTipovi.Attach(edited);
                db.Entry(edited).State = System.Data.Entity.EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    TempData["InfoMessage"] = new InfoMessage("Tip kursa '" + model.Naziv + "' uspješno editovan.", InfoMessageType.success);
                }
                catch (Exception)
                {
                    TempData["InfoMessage"] = new InfoMessage("Tip kursa '" + model.Naziv + "' nije editovan.", InfoMessageType.danger);
                }
            }
            else
            {
                model.KursKategorijeDDL = KursKategorijaVM.KursKategorijeDDLSet(db.KursKategorije.ToList(), model.KursKategorijaID);
                return View(model);
            }
            return RedirectToAction("KursTipPrikaz");
        }
        public ActionResult KursTipPrikaz()
        {
            if (TempData["InfoMessage"] != null)
                ViewBag.InfoMessage = TempData["InfoMessage"];
            return View(db.KursTipovi.AsNoTracking().ToList());
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!db.Kursevi.Any(x => x.KursTipID == id))
            {
                try
                {
                    KursTip kt = new KursTip { KursTipID = id ?? 0 };
                    db.KursTipovi.Attach(kt);
                    db.KursTipovi.Remove(kt);
                    db.SaveChanges();
                    TempData["InfoMessage"] = new InfoMessage("Tip kursa uspješno obrisan.", InfoMessageType.success);
                    return RedirectToAction("KursTipPrikaz");

                }
                catch (Exception)
                {
                
                }
            }
            TempData["InfoMessage"] = new InfoMessage("Tip kursa nije obrisan.", InfoMessageType.danger);
            return RedirectToAction("KursTipPrikaz");
        }

        public ActionResult KursTipDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KursTip kt = db.KursTipovi.FirstOrDefault(x => x.KursTipID == id);
            if (kt == null)
            {
                return HttpNotFound();
            }
            return View(kt);
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