namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnotation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "DataCadastro", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Produto", "Nome", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produto", "Nome", c => c.String());
            DropColumn("dbo.Produto", "DataCadastro");
        }
    }
}
