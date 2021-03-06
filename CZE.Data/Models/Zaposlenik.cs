﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;

namespace CZE.Data.Models
{
    [Table("Zaposlenici")]
    public class Zaposlenik
    {
        [Key()]
        [ForeignKey("Osoba")]
        public int ZaposlenikID { get; set; }
        [Display(Name="Stepen obrazovanja")]
        public StepenObrazovanja.StepeniObrazovanja StepenObrazovanja { get; set; }
        [Required()]
        [Display(Name = "Broj radne knjižice")]
        [StringLength(50,ErrorMessage="Maximalno 50 karaktera")]
        public string BrojRadneKnjizice { get; set; }

        #region Virtual
        public virtual Osoba Osoba { get; set; }
        public virtual List<UgovorZaposlenja> UgovoriZaposljenja { get; set; }
        public virtual List<PlatnaLista> PlatneListe { get; set; }
        public virtual List<Grupa> Grupe { get; set; }
        public virtual List<UplataKandidata> UplateKandidata { get; set; }
        public virtual List<Certifikat> Certifikati { get; set; }
        #endregion

    }

    public static class StepenObrazovanja
    {
        public enum StepeniObrazovanja { SSS, VKV, VŠS, VSS, Bachelor, Magistratura, Doktorat }

        public static SelectList GetStepeneObrazovanja(StepeniObrazovanja selectedTipTelefona)
        {
            IEnumerable<StepeniObrazovanja> tipovi = Enum.GetValues(typeof(StepeniObrazovanja)).Cast<StepeniObrazovanja>();

            return new SelectList(tipovi, selectedTipTelefona);
        }
    }
}
