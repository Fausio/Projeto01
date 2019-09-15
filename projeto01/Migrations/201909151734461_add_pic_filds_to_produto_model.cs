namespace projeto01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_pic_filds_to_produto_model : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categorias", newName: "Categoria");
            RenameTable(name: "dbo.Produtoes", newName: "Produto");
            RenameTable(name: "dbo.Fabricantes", newName: "Fabricante");
            AddColumn("dbo.Produto", "DataCadastro", c => c.DateTime(nullable: false));
            AddColumn("dbo.Produto", "LogotipoMimeType", c => c.String());
            AddColumn("dbo.Produto", "Logotipo", c => c.Binary());
            AlterColumn("dbo.Produto", "Nome", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produto", "Nome", c => c.String());
            DropColumn("dbo.Produto", "Logotipo");
            DropColumn("dbo.Produto", "LogotipoMimeType");
            DropColumn("dbo.Produto", "DataCadastro");
            RenameTable(name: "dbo.Fabricante", newName: "Fabricantes");
            RenameTable(name: "dbo.Produto", newName: "Produtoes");
            RenameTable(name: "dbo.Categoria", newName: "Categorias");
        }
    }
}
