using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZE.Data.Models
{
    [Table("Termini")]
    public class Termin
    {
        public int TerminID { get; set; }
        public int BrojCasova { get; set; }
        public DateTime Datum { get; set; }

        public int GrupaID { get; set; }
        public virtual Grupa Grupa { get; set; }
        public virtual List<Prisustvo> Prisustva { get; set; }
    }
}
