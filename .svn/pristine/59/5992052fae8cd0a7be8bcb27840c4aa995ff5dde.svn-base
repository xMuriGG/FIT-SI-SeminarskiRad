using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Mvc;
namespace CZE.Data.Models
{
    [Table("BrojeviTelefona")]
    public class BrojTelefona
    {
        public int BrojTelefonaID { get; set; }  
        public string Broj { get; set; }
        public TipTelefona.TipoviTelefona TipTelefona { get; set; }

        public int OsobaID { get; set; }
        public virtual Osoba Osoba { get; set; }
    }
    public static class TipTelefona{
        public enum TipoviTelefona { Mobilni,Poslovni,Kucni,Fax}

        public static SelectList GetTipoveTelefona()
        {
            IEnumerable<TipoviTelefona> tipovi = Enum.GetValues(typeof(TipoviTelefona)).Cast<TipoviTelefona>();

            //IEnumerable<SelectListItem> lista =
            //    from tip in tipovi
            //    select new SelectListItem
            //    {
            //        Text=tip.ToString(),
            //        Value=tip.ToString(),
            //        Selected=tip==selectedTipTelefona
            //    };

            return new SelectList(tipovi);
        }
        public static SelectList GetTipoveTelefona(TipoviTelefona selectedTipTelefona)
        {
            IEnumerable<TipoviTelefona> tipovi = Enum.GetValues(typeof(TipoviTelefona)).Cast<TipoviTelefona>();    
            return new SelectList(tipovi,selectedTipTelefona);
        }
    }

    
}
