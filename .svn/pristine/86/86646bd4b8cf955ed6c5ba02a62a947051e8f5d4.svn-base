namespace CZE.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrojeviTelefona",
                c => new
                    {
                        BrojTelefonaID = c.Int(nullable: false, identity: true),
                        Broj = c.String(nullable: false, maxLength: 15),
                        TipTelefona = c.Int(nullable: false),
                        OsobaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BrojTelefonaID)
                .ForeignKey("dbo.Osobe", t => t.OsobaID)
                .Index(t => t.OsobaID);
            
            CreateTable(
                "dbo.Osobe",
                c => new
                    {
                        OsobaID = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 50),
                        Prezime = c.String(nullable: false, maxLength: 50),
                        DatumRodjenja = c.DateTime(nullable: false),
                        Spol = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Adresa = c.String(nullable: false, maxLength: 100),
                        GradID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OsobaID)
                .ForeignKey("dbo.Gradovi", t => t.GradID)
                .Index(t => t.GradID);
            
            CreateTable(
                "dbo.Kandidati",
                c => new
                    {
                        KandidatID = c.Int(nullable: false),
                        DatumUpisa = c.DateTime(nullable: false),
                        Biljeske = c.String(),
                    })
                .PrimaryKey(t => t.KandidatID)
                .ForeignKey("dbo.Osobe", t => t.KandidatID)
                .Index(t => t.KandidatID);
            
            CreateTable(
                "dbo.GrupaKandidati",
                c => new
                    {
                        GrupaKandidatiID = c.Int(nullable: false, identity: true),
                        KandidatID = c.Int(nullable: false),
                        GrupaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GrupaKandidatiID)
                .ForeignKey("dbo.Grupe", t => t.GrupaID)
                .ForeignKey("dbo.Kandidati", t => t.KandidatID)
                .Index(t => t.KandidatID)
                .Index(t => t.GrupaID);
            
            CreateTable(
                "dbo.Certifikati",
                c => new
                    {
                        CertifikatID = c.Int(nullable: false, identity: true),
                        DatumUrucenja = c.DateTime(nullable: false),
                        Biljeske = c.String(),
                        GrupaKandidatiID = c.Int(nullable: false),
                        ZaposlenikID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CertifikatID)
                .ForeignKey("dbo.GrupaKandidati", t => t.GrupaKandidatiID)
                .ForeignKey("dbo.Zaposlenici", t => t.ZaposlenikID)
                .Index(t => t.GrupaKandidatiID)
                .Index(t => t.ZaposlenikID);
            
            CreateTable(
                "dbo.Zaposlenici",
                c => new
                    {
                        ZaposlenikID = c.Int(nullable: false),
                        StepenObrazovanja = c.Int(nullable: false),
                        BrojRadneKnjizice = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ZaposlenikID)
                .ForeignKey("dbo.Osobe", t => t.ZaposlenikID)
                .Index(t => t.ZaposlenikID);
            
            CreateTable(
                "dbo.Grupe",
                c => new
                    {
                        GrupaID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 100),
                        Pocetak = c.DateTime(nullable: false),
                        Kraj = c.DateTime(),
                        Aktivna = c.Boolean(nullable: false),
                        KursID = c.Int(nullable: false),
                        ZaposlenikID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GrupaID)
                .ForeignKey("dbo.Kurs", t => t.KursID)
                .ForeignKey("dbo.Zaposlenici", t => t.ZaposlenikID)
                .Index(t => t.KursID)
                .Index(t => t.ZaposlenikID);
            
            CreateTable(
                "dbo.Kurs",
                c => new
                    {
                        KursID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 100),
                        KursTipID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KursID)
                .ForeignKey("dbo.KursTipovi", t => t.KursTipID)
                .Index(t => t.KursTipID);
            
            CreateTable(
                "dbo.KursTipovi",
                c => new
                    {
                        KursTipID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 100),
                        Trajanje = c.Int(nullable: false),
                        Cijena = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.KursTipID);
            
            CreateTable(
                "dbo.Termini",
                c => new
                    {
                        TerminID = c.Int(nullable: false, identity: true),
                        BrojCasova = c.Int(nullable: false),
                        Datum = c.DateTime(nullable: false),
                        GrupaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TerminID)
                .ForeignKey("dbo.Grupe", t => t.GrupaID)
                .Index(t => t.GrupaID);
            
            CreateTable(
                "dbo.Prisustva",
                c => new
                    {
                        KandidatID = c.Int(nullable: false),
                        TerminID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.KandidatID, t.TerminID })
                .ForeignKey("dbo.Kandidati", t => t.KandidatID)
                .ForeignKey("dbo.Termini", t => t.TerminID)
                .Index(t => t.KandidatID)
                .Index(t => t.TerminID);
            
            CreateTable(
                "dbo.UplateKandidata",
                c => new
                    {
                        UplataKandidataID = c.Int(nullable: false, identity: true),
                        Kolicina = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StatusUplate = c.Boolean(nullable: false),
                        RacunIzdat = c.Boolean(nullable: false),
                        Biljeske = c.String(),
                        DatumUplate = c.DateTime(nullable: false),
                        KandidatID = c.Int(nullable: false),
                        GrupaID = c.Int(nullable: false),
                        ZaposlenikID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UplataKandidataID)
                .ForeignKey("dbo.Grupe", t => t.GrupaID)
                .ForeignKey("dbo.Kandidati", t => t.KandidatID)
                .ForeignKey("dbo.Zaposlenici", t => t.ZaposlenikID)
                .Index(t => t.KandidatID)
                .Index(t => t.GrupaID)
                .Index(t => t.ZaposlenikID);
            
            CreateTable(
                "dbo.PlatneListe",
                c => new
                    {
                        PlatnaListaID = c.Int(nullable: false, identity: true),
                        EfektivniSati = c.Int(nullable: false),
                        IznosPlate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Svrha = c.String(nullable: false, maxLength: 100),
                        ObracunskiPeriodID = c.Int(nullable: false),
                        ZaposlenikID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlatnaListaID)
                .ForeignKey("dbo.ObracunskiPeriodi", t => t.ObracunskiPeriodID)
                .ForeignKey("dbo.Zaposlenici", t => t.ZaposlenikID)
                .Index(t => t.ObracunskiPeriodID)
                .Index(t => t.ZaposlenikID);
            
            CreateTable(
                "dbo.ObracunskiPeriodi",
                c => new
                    {
                        ObracunskiPeriodID = c.Int(nullable: false, identity: true),
                        DatumObracuna = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ObracunskiPeriodID);
            
            CreateTable(
                "dbo.UgovoriZaposlenja",
                c => new
                    {
                        UgovorZaposlenjaID = c.Int(nullable: false, identity: true),
                        PozicijaKompanijeID = c.Int(nullable: false),
                        OpisPosla = c.String(),
                        DatumPocetkaUgovora = c.DateTime(nullable: false),
                        Period = c.Int(),
                        Koeficijent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                        ZaposlenikID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UgovorZaposlenjaID)
                .ForeignKey("dbo.PozicijeKompanije", t => t.PozicijaKompanijeID)
                .ForeignKey("dbo.Zaposlenici", t => t.ZaposlenikID)
                .Index(t => t.PozicijaKompanijeID)
                .Index(t => t.ZaposlenikID);
            
            CreateTable(
                "dbo.PozicijeKompanije",
                c => new
                    {
                        PozicijaKompanijeID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PozicijaKompanijeID);
            
            CreateTable(
                "dbo.Gradovi",
                c => new
                    {
                        GradID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 50),
                        PTT = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.GradID);
            
            CreateTable(
                "dbo.KorisnickiNalozi",
                c => new
                    {
                        KorisnickiNalogID = c.Int(nullable: false),
                        KorisnickoIme = c.String(nullable: false, maxLength: 50),
                        Lozinka = c.String(nullable: false, maxLength: 50),
                        Aktivan = c.Boolean(nullable: false),
                        UlogaKorisnikaID = c.Int(nullable: false),
                        UlogaKorisnika = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KorisnickiNalogID)
                .ForeignKey("dbo.Osobe", t => t.KorisnickiNalogID)
                .Index(t => t.KorisnickiNalogID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KorisnickiNalozi", "KorisnickiNalogID", "dbo.Osobe");
            DropForeignKey("dbo.Osobe", "GradID", "dbo.Gradovi");
            DropForeignKey("dbo.Kandidati", "KandidatID", "dbo.Osobe");
            DropForeignKey("dbo.GrupaKandidati", "KandidatID", "dbo.Kandidati");
            DropForeignKey("dbo.UgovoriZaposlenja", "ZaposlenikID", "dbo.Zaposlenici");
            DropForeignKey("dbo.UgovoriZaposlenja", "PozicijaKompanijeID", "dbo.PozicijeKompanije");
            DropForeignKey("dbo.PlatneListe", "ZaposlenikID", "dbo.Zaposlenici");
            DropForeignKey("dbo.PlatneListe", "ObracunskiPeriodID", "dbo.ObracunskiPeriodi");
            DropForeignKey("dbo.Zaposlenici", "ZaposlenikID", "dbo.Osobe");
            DropForeignKey("dbo.Grupe", "ZaposlenikID", "dbo.Zaposlenici");
            DropForeignKey("dbo.UplateKandidata", "ZaposlenikID", "dbo.Zaposlenici");
            DropForeignKey("dbo.UplateKandidata", "KandidatID", "dbo.Kandidati");
            DropForeignKey("dbo.UplateKandidata", "GrupaID", "dbo.Grupe");
            DropForeignKey("dbo.Prisustva", "TerminID", "dbo.Termini");
            DropForeignKey("dbo.Prisustva", "KandidatID", "dbo.Kandidati");
            DropForeignKey("dbo.Termini", "GrupaID", "dbo.Grupe");
            DropForeignKey("dbo.Kurs", "KursTipID", "dbo.KursTipovi");
            DropForeignKey("dbo.Grupe", "KursID", "dbo.Kurs");
            DropForeignKey("dbo.GrupaKandidati", "GrupaID", "dbo.Grupe");
            DropForeignKey("dbo.Certifikati", "ZaposlenikID", "dbo.Zaposlenici");
            DropForeignKey("dbo.Certifikati", "GrupaKandidatiID", "dbo.GrupaKandidati");
            DropForeignKey("dbo.BrojeviTelefona", "OsobaID", "dbo.Osobe");
            DropIndex("dbo.KorisnickiNalozi", new[] { "KorisnickiNalogID" });
            DropIndex("dbo.UgovoriZaposlenja", new[] { "ZaposlenikID" });
            DropIndex("dbo.UgovoriZaposlenja", new[] { "PozicijaKompanijeID" });
            DropIndex("dbo.PlatneListe", new[] { "ZaposlenikID" });
            DropIndex("dbo.PlatneListe", new[] { "ObracunskiPeriodID" });
            DropIndex("dbo.UplateKandidata", new[] { "ZaposlenikID" });
            DropIndex("dbo.UplateKandidata", new[] { "GrupaID" });
            DropIndex("dbo.UplateKandidata", new[] { "KandidatID" });
            DropIndex("dbo.Prisustva", new[] { "TerminID" });
            DropIndex("dbo.Prisustva", new[] { "KandidatID" });
            DropIndex("dbo.Termini", new[] { "GrupaID" });
            DropIndex("dbo.Kurs", new[] { "KursTipID" });
            DropIndex("dbo.Grupe", new[] { "ZaposlenikID" });
            DropIndex("dbo.Grupe", new[] { "KursID" });
            DropIndex("dbo.Zaposlenici", new[] { "ZaposlenikID" });
            DropIndex("dbo.Certifikati", new[] { "ZaposlenikID" });
            DropIndex("dbo.Certifikati", new[] { "GrupaKandidatiID" });
            DropIndex("dbo.GrupaKandidati", new[] { "GrupaID" });
            DropIndex("dbo.GrupaKandidati", new[] { "KandidatID" });
            DropIndex("dbo.Kandidati", new[] { "KandidatID" });
            DropIndex("dbo.Osobe", new[] { "GradID" });
            DropIndex("dbo.BrojeviTelefona", new[] { "OsobaID" });
            DropTable("dbo.KorisnickiNalozi");
            DropTable("dbo.Gradovi");
            DropTable("dbo.PozicijeKompanije");
            DropTable("dbo.UgovoriZaposlenja");
            DropTable("dbo.ObracunskiPeriodi");
            DropTable("dbo.PlatneListe");
            DropTable("dbo.UplateKandidata");
            DropTable("dbo.Prisustva");
            DropTable("dbo.Termini");
            DropTable("dbo.KursTipovi");
            DropTable("dbo.Kurs");
            DropTable("dbo.Grupe");
            DropTable("dbo.Zaposlenici");
            DropTable("dbo.Certifikati");
            DropTable("dbo.GrupaKandidati");
            DropTable("dbo.Kandidati");
            DropTable("dbo.Osobe");
            DropTable("dbo.BrojeviTelefona");
        }
    }
}
