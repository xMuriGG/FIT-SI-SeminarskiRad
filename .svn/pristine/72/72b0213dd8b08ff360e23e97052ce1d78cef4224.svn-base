namespace CZE.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UgovorZaposlenjaUpload : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UgovoriZaposlenja", "UgovorFile", c => c.Binary());
            AddColumn("dbo.UgovoriZaposlenja", "UgovorFileName", c => c.String());
            AddColumn("dbo.UgovoriZaposlenja", "UgovorFileType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UgovoriZaposlenja", "UgovorFileType");
            DropColumn("dbo.UgovoriZaposlenja", "UgovorFileName");
            DropColumn("dbo.UgovoriZaposlenja", "UgovorFile");
        }
    }
}
