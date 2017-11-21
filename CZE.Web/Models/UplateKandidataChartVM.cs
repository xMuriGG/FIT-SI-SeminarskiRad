using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZE.Web.Models
{
    public class UplateKandidataChartVM
    {
        public List<UplateKandidataChartData> Data { get; set; }
        public List<SelectListItem> GodineDDL { get; set; }
    }
}