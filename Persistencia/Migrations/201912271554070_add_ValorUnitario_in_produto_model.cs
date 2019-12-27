namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_ValorUnitario_in_produto_model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "ValorUnitario", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produto", "ValorUnitario");
        }
    }
}
