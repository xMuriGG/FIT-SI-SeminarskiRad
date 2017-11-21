using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZE.Data.Models
{
    [Table("Adrese")]
    public class Adresa
    {
        public int AdresaID { get; set; }
        public string Ulica { get; set; }

        public int GradID { get; set; }
        public virtual Grad Grad { get; set; }
        public int OsobaID { get; set; }
        public virtual Osoba Osoba { get; set; }
    }
}
