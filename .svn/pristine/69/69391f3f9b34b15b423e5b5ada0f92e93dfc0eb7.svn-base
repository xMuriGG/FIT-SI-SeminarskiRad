using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZE.Data.Models
{
    [Table("Prisustva")]
    public class Prisustvo
    {
        public int TerminID { get; set; }
        public virtual Termin Termin { get; set; }
        public int KandidatID { get; set; }
        public virtual Kandidat Kandidat { get; set; }
    }
}
