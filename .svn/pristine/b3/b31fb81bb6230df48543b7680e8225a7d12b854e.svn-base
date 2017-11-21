using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZE.Data.Models
{
    [Table("PlatneListe")]
    public class PlatnaLista
    {
        public int PlatnaListaID { get; set; }
        public int EfektivniSati { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal IznosPlate { get; set; } //Koeficijent * EfektivniSati
        public string Svrha { get; set; }

        public int ObracunskiPeriodID { get; set; }
        public virtual ObracunskiPeriod ObracinskiMjesec { get; set; }
        public int ZaposlenikID { get; set; }
        public virtual Zaposlenik Zaposlenik { get; set; }
    }
}
