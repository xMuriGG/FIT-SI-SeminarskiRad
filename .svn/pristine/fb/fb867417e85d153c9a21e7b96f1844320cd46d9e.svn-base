namespace CZE.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GradoviPTTRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Gradovi", "PTT");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gradovi", "PTT", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
