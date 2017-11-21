namespace CZE.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UplateKandidata_VezaNaGrupaKandidati : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UplateKandidata", "GrupaID", "dbo.Grupe");
            DropForeignKey("dbo.UplateKandidata", "KandidatID", "dbo.Kandidati");
            DropIndex("dbo.UplateKandidata", new[] { "KandidatID" });
            DropIndex("dbo.UplateKandidata", new[] { "GrupaID" });
            AddColumn("dbo.UplateKandidata", "GrupaKandidatiID", c => c.Int(nullable: false));
            CreateIndex("dbo.UplateKandidata", "GrupaKandidatiID");
            AddForeignKey("dbo.UplateKandidata", "GrupaKandidatiID", "dbo.GrupaKandidati", "GrupaKandidatiID");
            DropColumn("dbo.UplateKandidata", "KandidatID");
            DropColumn("dbo.UplateKandidata", "GrupaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UplateKandidata", "GrupaID", c => c.Int(nullable: false));
            AddColumn("dbo.UplateKandidata", "KandidatID", c => c.Int(nullable: false));
            DropForeignKey("dbo.UplateKandidata", "GrupaKandidatiID", "dbo.GrupaKandidati");
            DropIndex("dbo.UplateKandidata", new[] { "GrupaKandidatiID" });
            DropColumn("dbo.UplateKandidata", "GrupaKandidatiID");
            CreateIndex("dbo.UplateKandidata", "GrupaID");
            CreateIndex("dbo.UplateKandidata", "KandidatID");
            AddForeignKey("dbo.UplateKandidata", "KandidatID", "dbo.Kandidati", "KandidatID");
            AddForeignKey("dbo.UplateKandidata", "GrupaID", "dbo.Grupe", "GrupaID");
        }
    }
}
