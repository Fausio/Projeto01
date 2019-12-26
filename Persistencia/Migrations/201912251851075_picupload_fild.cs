namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class picupload_fild : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "LogotipoMimeType", c => c.String());
            AddColumn("dbo.Produto", "Logotipo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produto", "Logotipo");
            DropColumn("dbo.Produto", "LogotipoMimeType");
        }
    }
}
