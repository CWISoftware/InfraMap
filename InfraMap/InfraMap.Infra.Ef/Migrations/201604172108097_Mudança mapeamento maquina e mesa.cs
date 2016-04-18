namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mudançamapeamentomaquinaemesa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mesa", "Maquina_Id", "dbo.Maquina");
            DropIndex("dbo.Mesa", new[] { "Maquina_Id" });
            CreateTable(
                "dbo.MaquinaPessoal",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Patrimonio = c.Int(nullable: false),
                        EtiquetaServico = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maquina", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ModeloMaquina",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Mesa", "PontoRede", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Mesa", "PontoTelefone", c => c.String(maxLength: 50));
            AddColumn("dbo.Mesa", "PontoEletrico", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Mesa", "MaquinaPessoal_Id", c => c.Int());
            AddColumn("dbo.Maquina", "ModeloMaquina_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Maquina", "TipoMaquina", c => c.Int(nullable: false));
            AddColumn("dbo.Maquina", "HD", c => c.Int());
            AddColumn("dbo.Maquina", "SSD", c => c.Int());
            AddColumn("dbo.Maquina", "PenteMemoriaRamGB", c => c.Int(nullable: false));
            AddColumn("dbo.Maquina", "UnidadesMemoriaRam", c => c.Int(nullable: false));
            AddColumn("dbo.Maquina", "Fonte", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Maquina", "PlacaMae", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Maquina", "Processador", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Maquina", "PlacaRede", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Maquina", "DriverOtico", c => c.String(maxLength: 200));
            CreateIndex("dbo.Mesa", "MaquinaPessoal_Id");
            CreateIndex("dbo.Maquina", "ModeloMaquina_Id");
            AddForeignKey("dbo.Maquina", "ModeloMaquina_Id", "dbo.ModeloMaquina", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Mesa", "MaquinaPessoal_Id", "dbo.MaquinaPessoal", "Id");
            DropColumn("dbo.Mesa", "Maquina_Id");
            DropColumn("dbo.Maquina", "Nome");
            DropColumn("dbo.Maquina", "Tipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Maquina", "Tipo", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Maquina", "Nome", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Mesa", "Maquina_Id", c => c.Int());
            DropForeignKey("dbo.Mesa", "MaquinaPessoal_Id", "dbo.MaquinaPessoal");
            DropForeignKey("dbo.MaquinaPessoal", "Id", "dbo.Maquina");
            DropForeignKey("dbo.Maquina", "ModeloMaquina_Id", "dbo.ModeloMaquina");
            DropIndex("dbo.Maquina", new[] { "ModeloMaquina_Id" });
            DropIndex("dbo.MaquinaPessoal", new[] { "Id" });
            DropIndex("dbo.Mesa", new[] { "MaquinaPessoal_Id" });
            DropColumn("dbo.Maquina", "DriverOtico");
            DropColumn("dbo.Maquina", "PlacaRede");
            DropColumn("dbo.Maquina", "Processador");
            DropColumn("dbo.Maquina", "PlacaMae");
            DropColumn("dbo.Maquina", "Fonte");
            DropColumn("dbo.Maquina", "UnidadesMemoriaRam");
            DropColumn("dbo.Maquina", "PenteMemoriaRamGB");
            DropColumn("dbo.Maquina", "SSD");
            DropColumn("dbo.Maquina", "HD");
            DropColumn("dbo.Maquina", "TipoMaquina");
            DropColumn("dbo.Maquina", "ModeloMaquina_Id");
            DropColumn("dbo.Mesa", "MaquinaPessoal_Id");
            DropColumn("dbo.Mesa", "PontoEletrico");
            DropColumn("dbo.Mesa", "PontoTelefone");
            DropColumn("dbo.Mesa", "PontoRede");
            DropTable("dbo.ModeloMaquina");
            DropTable("dbo.MaquinaPessoal");
            CreateIndex("dbo.Mesa", "Maquina_Id");
            AddForeignKey("dbo.Mesa", "Maquina_Id", "dbo.Maquina", "Id");
        }
    }
}
