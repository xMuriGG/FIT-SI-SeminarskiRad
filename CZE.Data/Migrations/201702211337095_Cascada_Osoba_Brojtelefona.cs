namespace CZE.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cascada_Osoba_Brojtelefona : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BrojeviTelefona", "OsobaID", "dbo.Osobe");
            AddForeignKey("dbo.BrojeviTelefona", "OsobaID", "dbo.Osobe", "OsobaID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BrojeviTelefona", "OsobaID", "dbo.Osobe");
            AddForeignKey("dbo.BrojeviTelefona", "OsobaID", "dbo.Osobe", "OsobaID");
        }
    }
}
