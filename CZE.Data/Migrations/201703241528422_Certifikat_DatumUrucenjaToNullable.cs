namespace CZE.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Certifikat_DatumUrucenjaToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Certifikati", "DatumUrucenja", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Certifikati", "DatumUrucenja", c => c.DateTime(nullable: false));
        }
    }
}
