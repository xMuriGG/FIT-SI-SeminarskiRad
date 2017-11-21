﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZE.Data.Models
{
    [Table("Gradovi")]
   public class Grad
    {
        public int GradID { get; set; }
        public string Naziv { get; set; }
        //public string PTT { get; set; }
        public virtual List<Osoba> Osobe { get; set; }       
    }
}
