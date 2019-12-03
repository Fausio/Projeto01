namespace projeto01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Fabricantes",
                c => new
                    {
                        FabricanteID = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.FabricanteID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fabricantes");
            DropTable("dbo.Categorias");
        }
    }
}
