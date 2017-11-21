using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZE.Data.Models
{
    [Table("ObracunskiPeriodi")]
    public class ObracunskiPeriod
    {
        public int ObracunskiPeriodID { get; set; }
        [Display(Name="Datum obračuna")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatumObracuna { get; set; }

         public virtual List<PlatnaLista> PlatnaLista { get; set; }
    }
}
