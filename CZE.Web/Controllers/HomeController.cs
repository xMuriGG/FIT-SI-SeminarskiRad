﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using CZE.Data.Models;
using CZE.Data;
using CZE.Web.Models;
using System.Web.Script.Serialization;
using CZE.Web.Helper;

namespace CZE.Web.Controllers
{
    [Autorizacija(
        UlogeKorisnika.Kandidat,
        UlogeKorisnika.Predavac,
        UlogeKorisnika.Administrativni_Radnik,
        UlogeKorisnika.Direktor,
        UlogeKorisnika.Administrator
        )]
    public class HomeController : Controller
    {
        CZEContext db = new CZEContext();
        DashboardDataVM dashData = new DashboardDataVM();

        public ActionResult DashBoard()
        {           
            if (TempData["InfoMessage"] != null)
            {
                ViewBag.InfoMessage = (Helper.InfoMessage)TempData["InfoMessage"];
            }
            dashData.BrojOsoba = db.Osobe.Count();
            dashData.BrojKandidata = db.Kandidats.Count();
            dashData.BrojZaposlenika = db.Zaposlenici.Count();

            return View(dashData);
        }
        public PartialViewResult BrojKandidataChart(int godinaDDL_br = 0)
        {
            dashData.BrojKandidataChart = new BrojKandidataChartVM();

            dashData.BrojKandidataChart.GodineDDL = BrojKandidataChartGodineDDL(godinaDDL_br);

            if (dashData.BrojKandidataChart.GodineDDL.Count > 0)
            {
                if (godinaDDL_br == 0)
                {
                    godinaDDL_br = Convert.ToInt32(dashData.BrojKandidataChart.GodineDDL.FirstOrDefault().Value);
                }
                dashData.BrojKandidataChart.Data = db.Kandidats.Where(x => x.DatumUpisa.Year == godinaDDL_br)
                    .GroupBy(x => x.DatumUpisa.Month)
                    .Select(g => new BrojKandidataChartData() { xDatum = godinaDDL_br + "-" + g.Key, yCount = g.Count() })
                    .ToList();
            }

            return PartialView("_BrojKandidataChart", dashData.BrojKandidataChart);
        }
        public PartialViewResult UplateKandidataChart(int godinaDDL_upl = 0)
        {
            dashData.UplateKandidataChart = new UplateKandidataChartVM();
            dashData.UplateKandidataChart.GodineDDL = UplateKandidataChartGodineDDL(godinaDDL_upl);

            if (dashData.UplateKandidataChart.GodineDDL.Count > 0)
            {
                if (godinaDDL_upl == 0)
                {
                    godinaDDL_upl = Convert.ToInt32(dashData.UplateKandidataChart.GodineDDL.FirstOrDefault().Value);
                }
                dashData.UplateKandidataChart.Data = db.UplateKandidata.Where(x => x.DatumUplate.Year == godinaDDL_upl)
                    .GroupBy(x => x.DatumUplate.Month)
                    .Select(g => new UplateKandidataChartData() { xDatum = godinaDDL_upl + "-" + g.Key, yKolicina = g.Sum(x => x.Kolicina) })
                    .ToList();
            }

            return PartialView("_UplateKandidataChart", dashData.UplateKandidataChart);
        }
        [NonAction]
        private List<SelectListItem> BrojKandidataChartGodineDDL(int selected = 0)
        {
            return db.Kandidats
                .AsNoTracking()
                .Select(s => new SelectListItem
                {
                    Value = s.DatumUpisa.Year.ToString(),
                    Text = s.DatumUpisa.Year.ToString(),
                    Selected = s.DatumUpisa.Year == selected
                })
                .Distinct()
                .OrderByDescending(x => x)
                .ToList();
        }
        [NonAction]
        private List<SelectListItem> UplateKandidataChartGodineDDL(int selected = 0)
        {
            return db.UplateKandidata
                .AsNoTracking()
                .Select(s => new SelectListItem
                {
                    Value = s.DatumUplate.Year.ToString(),
                    Text = s.DatumUplate.Year.ToString(),
                    Selected = s.DatumUplate.Year == selected
                })
                .Distinct()
                .OrderByDescending(x => x)
                .ToList();
        }

    }
}