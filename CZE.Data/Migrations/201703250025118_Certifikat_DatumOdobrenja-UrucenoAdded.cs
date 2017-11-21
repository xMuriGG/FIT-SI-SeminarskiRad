namespace CZE.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Certifikat_DatumOdobrenjaUrucenoAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Certifikati", "DatumOdobrenja", c => c.DateTime(nullable: false));
            AddColumn("dbo.Certifikati", "Uruceno", c => c.Boolean(nullable: false));
            DropColumn("dbo.Certifikati", "DatumUrucenja");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Certifikati", "DatumUrucenja", c => c.DateTime());
            DropColumn("dbo.Certifikati", "Uruceno");
            DropColumn("dbo.Certifikati", "DatumOdobrenja");
        }
    }
}
