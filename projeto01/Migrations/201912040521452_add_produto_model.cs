namespace projeto01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_produto_model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoId = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        CategoriaId = c.Long(),
                        FabricanteId = c.Long(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId)
                .ForeignKey("dbo.Fabricantes", t => t.FabricanteId)
                .Index(t => t.CategoriaId)
                .Index(t => t.FabricanteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "FabricanteId", "dbo.Fabricantes");
            DropForeignKey("dbo.Produtoes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtoes", new[] { "FabricanteId" });
            DropIndex("dbo.Produtoes", new[] { "CategoriaId" });
            DropTable("dbo.Produtoes");
        }
    }
}
