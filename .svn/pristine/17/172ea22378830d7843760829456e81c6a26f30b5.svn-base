using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZE.Data.Models
{
    [Table("Certifikati")]
    public class Certifikat
    {
        public int CertifikatID { get; set; }
        public int GrupaKandidatiID { get; set; }
        public virtual GrupaKandidati GrupaKandidati { get; set; }
        public DateTime DatumOdobrenja { get; set; }
        public bool Uruceno { get; set; }
        public string Biljeske { get; set; }

        public int ZaposlenikID { get; set; }
        public virtual Zaposlenik Zaposlenik { get; set; }      
    }
}
