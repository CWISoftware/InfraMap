namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoverCamposMaquina : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Maquina", "Fonte");
            DropColumn("dbo.Maquina", "PlacaMae");
            DropColumn("dbo.Maquina", "PlacaRede");
            DropColumn("dbo.Maquina", "DriverOtico");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Maquina", "DriverOtico", c => c.String(maxLength: 200));
            AddColumn("dbo.Maquina", "PlacaRede", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Maquina", "PlacaMae", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Maquina", "Fonte", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
