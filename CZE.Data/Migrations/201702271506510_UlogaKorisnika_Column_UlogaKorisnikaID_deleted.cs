namespace CZE.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UlogaKorisnika_Column_UlogaKorisnikaID_deleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.KorisnickiNalozi", "UlogaKorisnikaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KorisnickiNalozi", "UlogaKorisnikaID", c => c.Int(nullable: false));
        }
    }
}
