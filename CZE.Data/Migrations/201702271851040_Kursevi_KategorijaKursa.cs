namespace CZE.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kursevi_KategorijaKursa : DbMigration
    {
        public override void Up()
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
            CreateIndex("dbo.KursTipovi", "KategorijaKursaID");
            AddForeignKey("dbo.KursTipovi", "KategorijaKursaID", "dbo.KategorijaKursas", "KategorijaKursaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KursTipovi", "KategorijaKursaID", "dbo.KategorijaKursas");
            DropIndex("dbo.KursTipovi", new[] { "KategorijaKursaID" });
            DropColumn("dbo.KursTipovi", "KategorijaKursaID");
            DropTable("dbo.KategorijaKursas");
        }
    }
}
