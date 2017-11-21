using CZE.Data;
using CZE.Data.Models;
using CZE.Web.Areas.Direktor.Models;
using CZE.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CZE.Web.Areas.Direktor.Controllers
{
    [Autorizacija(UlogeKorisnika.Direktor, UlogeKorisnika.Administrator)]

    public class PlatnaListaController : Controller
    {
        CZEContext db = new CZEContext();
       
        private PlatnaListaUnosVM PlatnaListaUnosInitial()
        {
            List<ObracunskiPeriod> oPeriodi = db.ObracunskiPeriodi.OrderByDescending(x => x.ObracunskiPeriodID).ToList();
            PlatnaListaUnosVM platnaListaVM = new PlatnaListaUnosVM(db, oPeriodi);
            return platnaListaVM;
        }
        public ActionResult PlatnaListaUnos(int selectedObracunskiPeriodId = 0)
        {
            if (TempData["InfoMessage"] != null)
            {
                ViewBag.InfoMessage = (Helper.InfoMessage)TempData["InfoMessage"];
            }
            PlatnaListaUnosVM platnaListaVM = PlatnaListaUnosInitial();
            platnaListaVM.ObracunskiPeriod = selectedObracunskiPeriodId;
            return View(platnaListaVM);
        }

        [HttpPost]
        public ActionResult PlatnaListaUnos(PlatnaListaUnosVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.Zaposlenici.Count(z => z.Selected == true) > 0)
                {
                    foreach (PlatnaListaUnosTableVM zaposlenik in model.Zaposlenici.Where(z => z.Selected == true).ToList())
                    {
                        db.PlatneListe.Add(new PlatnaLista()
                        {
                            EfektivniSati = model.EfektivniSati,
                            IznosPlate = model.IznosPlate,
                            Svrha = model.Svrha,
                            ObracunskiPeriodID = model.ObracunskiPeriod,
                            ZaposlenikID = zaposlenik.OsobaID

                        });
                    }
                    db.SaveChanges();
                    TempData["InfoMessage"] = new InfoMessage(
                        "Uspješno ste unijeli platnu listu za [" + db.PlatneListe.Local.Count() + "] zaposlenika",
                        InfoMessageType.success);
                return RedirectToAction("PlatnaListaUnos");
                }
                else
                {
                    ViewBag.InfoMessage = new InfoMessage("Barem jedan zaposlenik mora biti selektiran!", InfoMessageType.warning);
                }
            }
            PlatnaListaUnosVM platnaListaVM = PlatnaListaUnosInitial();
            model.Zaposlenici = platnaListaVM.Zaposlenici;
            model.ObracunskiPeriodDLL = platnaListaVM.ObracunskiPeriodDLL;
            return View(model);
        }

        public ActionResult PlatnaListaPrikaz(int oPeriod=0)
        {
            List<PlatnaLista> platneListe = db.PlatneListe.Where(x=>oPeriod==0 || x.ObracinskiMjesec.ObracunskiPeriodID==oPeriod).ToList();
            List<SelectListItem> oP = ObracunskiPeriodVM.ObracunskiPeriodiDDLSet(db.ObracunskiPeriodi.AsNoTracking().ToList());
           
            oP.Insert(0,new SelectListItem { Text = "All", Value = "0" });
            ViewBag.oPeriodi = oP;

            return View(platneListe);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }           
                try
                {
                    PlatnaLista pl = new PlatnaLista { PlatnaListaID = id ?? 0 };
                    db.PlatneListe.Attach(pl);
                    db.PlatneListe.Remove(pl);
                    db.SaveChanges();                 
                }
                catch (Exception)
                {

                }

                return RedirectToAction("PlatnaListaPrikaz");
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