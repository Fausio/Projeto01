namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_pic_filds_to_produto_model : DbMigration
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
