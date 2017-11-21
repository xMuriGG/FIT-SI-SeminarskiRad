namespace CZE.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kursevi_Dorada : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.KursTipovi", "KategorijaKursaID", "dbo.KategorijaKursas");
            DropIndex("dbo.KursTipovi", new[] { "KategorijaKursaID" });
            CreateTable(
                "dbo.KursKategorijas",
                c => new
                    {
                        KursKategorijaID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.KursKategorijaID);
            
            AddColumn("dbo.Kurs", "Opis", c => c.String());
            AddColumn("dbo.KursTipovi", "Opis", c => c.String(nullable: false, maxLength: 1000));
            AddColumn("dbo.KursTipovi", "KursKategorijaID", c => c.Int(nullable: false));
            AlterColumn("dbo.KursTipovi", "Naziv", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.KursTipovi", "KursKategorijaID");
            AddForeignKey("dbo.KursTipovi", "KursKategorijaID", "dbo.KursKategorijas", "KursKategorijaID");
            DropColumn("dbo.KursTipovi", "KategorijaKursaID");
            DropTable("dbo.KategorijaKursas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.KategorijaKursas",
                c => new
                    {
                        KategorijaKursaID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.KategorijaKursaID);
            
            AddColumn("dbo.KursTipovi", "KategorijaKursaID", c => c.Int(nullable: false));
            DropForeignKey("dbo.KursTipovi", "KursKategorijaID", "dbo.KursKategorijas");
            DropIndex("dbo.KursTipovi", new[] { "KursKategorijaID" });
            AlterColumn("dbo.KursTipovi", "Naziv", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.KursTipovi", "KursKategorijaID");
            DropColumn("dbo.KursTipovi", "Opis");
            DropColumn("dbo.Kurs", "Opis");
            DropTable("dbo.KursKategorijas");
            CreateIndex("dbo.KursTipovi", "KategorijaKursaID");
            AddForeignKey("dbo.KursTipovi", "KategorijaKursaID", "dbo.KategorijaKursas", "KategorijaKursaID");
        }
    }
}
