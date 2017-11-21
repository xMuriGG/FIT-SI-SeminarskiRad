using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CZE.Web.Areas.AdministrativniRadnik.Reports.IzradaCertifikata
{
    public partial class IzradaCertifikataWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int grupaKandidatId =int.Parse(Request.QueryString["Id"]);
                var data = IzradaCertifikataReportData.GetReportData(grupaKandidatId);
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", data));

                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}