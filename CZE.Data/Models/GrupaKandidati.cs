﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZE.Data.Models
{
    [Table("GrupaKandidati")]
    public class GrupaKandidati
    {
        public int GrupaKandidatiID { get; set; }
        public int KandidatID { get; set; }
        public virtual Kandidat Kandidat { get; set; }
        public int GrupaID { get; set; }
        public virtual Grupa Grupa { get; set; }

        public virtual List<Certifikat> Certifikati { get; set; }
        public virtual List<UplataKandidata> UplateKandidata { get; set; }
    }
}
