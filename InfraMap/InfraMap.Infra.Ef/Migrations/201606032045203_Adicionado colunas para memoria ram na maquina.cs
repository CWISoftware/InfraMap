namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionadocolunasparamemoriaramnamaquina : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Maquina", "MemoriaRamGB1", c => c.Int(nullable: false));
            AddColumn("dbo.Maquina", "MemoriaRamGB2", c => c.Int());
            AddColumn("dbo.Maquina", "MemoriaRamGB3", c => c.Int());
            AddColumn("dbo.Maquina", "MemoriaRamGB4", c => c.Int());
            DropColumn("dbo.Maquina", "PenteMemoriaRamGB");
            DropColumn("dbo.Maquina", "UnidadesMemoriaRam");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Maquina", "UnidadesMemoriaRam", c => c.Int(nullable: false));
            AddColumn("dbo.Maquina", "PenteMemoriaRamGB", c => c.Int(nullable: false));
            DropColumn("dbo.Maquina", "MemoriaRamGB4");
            DropColumn("dbo.Maquina", "MemoriaRamGB3");
            DropColumn("dbo.Maquina", "MemoriaRamGB2");
            DropColumn("dbo.Maquina", "MemoriaRamGB1");
        }
    }
}
