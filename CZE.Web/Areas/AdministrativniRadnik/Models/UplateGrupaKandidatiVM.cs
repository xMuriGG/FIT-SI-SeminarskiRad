using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CZE.Data.Models;
namespace CZE.Web.Areas.AdministrativniRadnik.Models
{
    public class UplateGrupaKandidatiVM
    {
        public int GrupaKandidatiID { get; set; }
        public int KandidatID { get; set; }
        public string GrupaDetails { get; set; }
        public string KandidatDetails { get; set; }
        public string UplataDetails { get; set; }
        public List<UplataKandidata> UplateKandidataTable { get; set; }

    }
}