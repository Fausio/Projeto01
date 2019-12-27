namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemCarrinho_to_coontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemCarrinho",
                c => new
                    {
                        ItemCarrinhoId = c.Long(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        ValorUnitario = c.Double(nullable: false),
                        Produto_ProdutoId = c.Long(),
                    })
                .PrimaryKey(t => t.ItemCarrinhoId)
                .ForeignKey("dbo.Produto", t => t.Produto_ProdutoId)
                .Index(t => t.Produto_ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemCarrinho", "Produto_ProdutoId", "dbo.Produto");
            DropIndex("dbo.ItemCarrinho", new[] { "Produto_ProdutoId" });
            DropTable("dbo.ItemCarrinho");
        }
    }
}
