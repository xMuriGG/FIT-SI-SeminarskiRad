﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZE.Data.Models
{
    [Table("UgovoriZaposlenja")]
    public class UgovorZaposlenja
    {
        public int UgovorZaposlenjaID { get; set; }
        public int PozicijaKompanijeID { get; set; }
        public int ZaposlenikID { get; set; }
        public DateTime DatumPocetkaUgovora { get; set; }
        public int? Period { get; set; } // u mjesecima null
        public decimal Koeficijent { get; set; }
        public bool Status { get; set; }
        public byte[] UgovorFile { get; set; }
        public string UgovorFileName { get; set; }
        public string UgovorFileType { get; set; }
        public string OpisPosla { get; set; }

        public virtual PozicijaKompanije PozicijaKompanije { get; set; }
        public virtual Zaposlenik Zaposlenik { get; set; }

        public UgovorZaposlenja()
        {
            Status = true;
            PozicijaKompanije = new PozicijaKompanije();
            Zaposlenik = new Zaposlenik();
        }
    }
}
