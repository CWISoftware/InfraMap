namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagemSede : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sede", "Cidade", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Sede", "Imagem", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Sede", "NomeCidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sede", "NomeCidade", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Sede", "Imagem");
            DropColumn("dbo.Sede", "Cidade");
        }
    }
}
