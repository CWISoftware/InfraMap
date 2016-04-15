namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteradoCamposdeMesa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mesa", "PontoRede", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Mesa", "PontoTelefone", c => c.String(maxLength: 50));
            AddColumn("dbo.Mesa", "PontoEletrico", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mesa", "PontoEletrico");
            DropColumn("dbo.Mesa", "PontoTelefone");
            DropColumn("dbo.Mesa", "PontoRede");
        }
    }
}
