namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trocadopontoderedeparalogico : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mesa", "PontoLogico1", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Mesa", "PontoLogico2", c => c.String(maxLength: 50));
            DropColumn("dbo.Mesa", "PontoRede");
            DropColumn("dbo.Mesa", "PontoTelefone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mesa", "PontoTelefone", c => c.String(maxLength: 50));
            AddColumn("dbo.Mesa", "PontoRede", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Mesa", "PontoLogico2");
            DropColumn("dbo.Mesa", "PontoLogico1");
        }
    }
}
