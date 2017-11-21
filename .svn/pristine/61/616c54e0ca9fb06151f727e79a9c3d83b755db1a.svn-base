using CZE.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZE.Web.Areas.Osoba.Models
{
    public class BrojTelefonaVM
    {
        public int BrojTelefonaID { get; set; }
        [Required(ErrorMessage="Broj je obavezno polje.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"\+?387-?\d{2}-?\d{3}-?\d{3}\d?", ErrorMessage = "Nije validan broj telefona.")]
        public string Broj { get; set; }
        public TipTelefona.TipoviTelefona TipTelefona { get; set; }
        public int OsobaID { get; set; }


        public BrojTelefonaVM()
        {
        }
    }
}