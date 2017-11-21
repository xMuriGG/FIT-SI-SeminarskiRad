using CZE.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZE.Data
{
    public class PocetnaBaza : DropCreateDatabaseAlways<CZEContext>
    {
        protected override void Seed(CZEContext context)
        {
            context.Gradovi.Add(new Grad() { Naziv = "Sarajevo" });
            context.Gradovi.Add(new Grad() { Naziv = "Mostar" });
            context.Gradovi.Add(new Grad() { Naziv = "Tuzla" });

            List<BrojTelefona> brojevi = new List<BrojTelefona>();
            brojevi.Add(new BrojTelefona() { Broj = "111111111111111", TipTelefona = TipTelefona.TipoviTelefona.Mobilni });
            brojevi.Add(new BrojTelefona() { Broj = "222222222222222", TipTelefona = TipTelefona.TipoviTelefona.Poslovni });
            brojevi.Add(new BrojTelefona() { Broj = "333333333333333", TipTelefona = TipTelefona.TipoviTelefona.Fax });
            brojevi.Add(new BrojTelefona() { Broj = "444444444444444", TipTelefona = TipTelefona.TipoviTelefona.Kucni });

            List<BrojTelefona> brojevi1 = new List<BrojTelefona>();
            brojevi.Add(new BrojTelefona() { Broj = "555555555555555", TipTelefona = TipTelefona.TipoviTelefona.Mobilni });
            brojevi.Add(new BrojTelefona() { Broj = "666666666666666", TipTelefona = TipTelefona.TipoviTelefona.Poslovni });
            brojevi.Add(new BrojTelefona() { Broj = "777777777777777", TipTelefona = TipTelefona.TipoviTelefona.Fax });
            brojevi.Add(new BrojTelefona() { Broj = "888888888888888", TipTelefona = TipTelefona.TipoviTelefona.Kucni });

            Osoba os = context.Osobe.Add(new Osoba()
            {
                Ime = "Muris",
                Prezime = "Cengic",
                DatumRodjenja = new DateTime(1992, 4, 30),
                Spol = Spol.M,
                Email = "Email@hotmail.com",
                GradID = 1,
                Adresa = "Skopljanska 10a",
                BrojeviTelefona = brojevi
            });
            Osoba os2 = context.Osobe.Add(new Osoba()
            {
                Ime = "Enes",
                Prezime = "Kapetanovic",
                DatumRodjenja = new DateTime(1996, 6, 23),
                Spol = Spol.M,
                Email = "Email@hotmail.com",
                GradID = 1,
                Adresa = "Grb 213d",
                BrojeviTelefona = brojevi1
            });

            context.Osobe.Add(new Osoba() { Ime = "Test1", Prezime = "Test1", DatumRodjenja = new DateTime(1952, 4, 30), Spol = Spol.Z, Email = "Test1Email@hotmail.com", GradID = 1, Adresa = "Test 15r", BrojeviTelefona = null });
            context.Osobe.Add(new Osoba() { Ime = "Test2", Prezime = "Test2", DatumRodjenja = new DateTime(1982, 4, 30), Spol = Spol.Z, Email = "Test2Email@hotmail.com", GradID = 2, Adresa = "Test 15r", BrojeviTelefona = null });
            context.Osobe.Add(new Osoba() { Ime = "Test3", Prezime = "Test3", DatumRodjenja = new DateTime(1978, 4, 30), Spol = Spol.M, Email = "Test3Email@hotmail.com", GradID = 3, Adresa = "Test 15r", BrojeviTelefona = null });
            context.Osobe.Add(new Osoba() { Ime = "Test4", Prezime = "Test4", DatumRodjenja = new DateTime(1967, 4, 30), Spol = Spol.Z, Email = "Test4Email@hotmail.com", GradID = 1, Adresa = "Test 15r", BrojeviTelefona = null });
            context.Osobe.Add(new Osoba() { Ime = "Test5", Prezime = "Test5", DatumRodjenja = new DateTime(1953, 4, 30), Spol = Spol.Z, Email = "Test5Email@hotmail.com", GradID = 2, Adresa = "Test 15r", BrojeviTelefona = null });

            List<PozicijaKompanije> pozicije = new List<PozicijaKompanije>();
            pozicije.Add(new PozicijaKompanije() { Naziv = "Administrativni radnik" });
            pozicije.Add(new PozicijaKompanije() { Naziv = "Direktor" });
            pozicije.Add(new PozicijaKompanije() { Naziv = "Domar" });
            pozicije.Add(new PozicijaKompanije() { Naziv = "Predavač" });

            context.PozicijeKompanije.AddRange(pozicije);

            context.Zaposlenici.Add(new Zaposlenik() { Osoba = os, StepenObrazovanja = StepenObrazovanja.StepeniObrazovanja.Bachelor, BrojRadneKnjizice = "235325252345" });
            context.Zaposlenici.Add(new Zaposlenik() { Osoba = os2, StepenObrazovanja = StepenObrazovanja.StepeniObrazovanja.Magistratura, BrojRadneKnjizice = "4325643643" });

            context.Kandidats.Add(new Kandidat()
            {
                Osoba = context.Osobe.Add(new Osoba() { Ime = "Test6", Prezime = "Test6", DatumRodjenja = new DateTime(1989, 8, 2), Spol = Spol.Z, Email = "Test6Email@hotmail.com", GradID = 2, Adresa = "Test 15r", BrojeviTelefona = null }),
                DatumUpisa = DateTime.Now
            });
            context.KorisnickiNalozi.Add(new KorisnickiNalog() { Aktivan = true, KorisnickoIme = "test", Lozinka = "test", Osoba = os, UlogaKorisnika = UlogeKorisnika.Administrator, KorisnickiNalogID = os.OsobaID });
            context.SaveChanges();
        }
    }
}
