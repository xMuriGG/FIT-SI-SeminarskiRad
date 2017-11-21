using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZE.Data.Models
{
    [Table("PozicijeKompanije")]
    public class PozicijaKompanije
    {
        public int PozicijaKompanijeID { get; set; }
        public string Naziv { get; set; }

        public virtual List<UgovorZaposlenja> UgovoriZaposlenja { get; set; }
    }
}
