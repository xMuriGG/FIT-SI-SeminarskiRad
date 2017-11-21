using CZE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//namespace CZE.Web.Areas.AdministrativniRadnik.Models
namespace CZE.Web.Areas.AdministrativniRadnik.Reports.IzradaCertifikata
{
    public class IzradaCertifikataReportData
    {
        public string ImePrezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string MjestoRodjenja { get; set; }
        public string NazivKursa { get; set; }
        public string NazivModula { get; set; }

        public static List<IzradaCertifikataReportData> GetReportData(int Id)
        {
            using (CZEContext db = new CZEContext())
            {
                IzradaCertifikataReportData data = db.Certifikati
                    .AsNoTracking()
                    .Where(x => x.CertifikatID == Id)
                    .Select(s => new IzradaCertifikataReportData
                    {
                        ImePrezime = s.GrupaKandidati.Kandidat.Osoba.Ime + " " + s.GrupaKandidati.Kandidat.Osoba.Prezime,
                        DatumRodjenja = s.GrupaKandidati.Kandidat.Osoba.DatumRodjenja,
                        MjestoRodjenja = s.GrupaKandidati.Kandidat.Osoba.MjestoRodjenja.Naziv,
                        NazivKursa = s.GrupaKandidati.Grupa.Kurs.KursTip.Naziv,
                        NazivModula = s.GrupaKandidati.Grupa.Kurs.Naziv
                    }).SingleOrDefault();
                return new List<IzradaCertifikataReportData> { data };
            }
        }

    }
}