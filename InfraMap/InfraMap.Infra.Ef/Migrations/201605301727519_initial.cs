namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Andar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                        Sede_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sede", t => t.Sede_Id, cascadeDelete: true)
                .Index(t => t.Sede_Id);
            
            CreateTable(
                "dbo.Mesa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Colaborador_Id = c.Int(),
                        MaquinaPessoal_Id = c.Int(),
                        Andar_Id = c.Int(nullable: false),
                        Ramal_Id = c.Int(),
                        PontoLogico1 = c.String(nullable: false, maxLength: 50),
                        PontoLogico2 = c.String(maxLength: 50),
                        PontoEletrico = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Andar", t => t.Andar_Id, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.Colaborador_Id)
                .ForeignKey("dbo.MaquinaPessoal", t => t.MaquinaPessoal_Id)
                .ForeignKey("dbo.Ramal", t => t.Ramal_Id)
                .Index(t => t.Colaborador_Id)
                .Index(t => t.MaquinaPessoal_Id)
                .Index(t => t.Andar_Id)
                .Index(t => t.Ramal_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 250),
                        Login = c.String(nullable: false, maxLength: 50),
                        Cor = c.String(maxLength: 50),
                        GerenteId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.GerenteId)
                .Index(t => t.Nome, name: "IX_Usuario_Nome")
                .Index(t => t.Login, unique: true, name: "IX_Usuario_Login")
                .Index(t => t.GerenteId);
            
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
                "dbo.Maquina",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModeloMaquina_Id = c.Int(nullable: false),
                        TipoMaquina = c.Int(nullable: false),
                        HD = c.Int(),
                        SSD = c.Int(),
                        PenteMemoriaRamGB = c.Int(nullable: false),
                        UnidadesMemoriaRam = c.Int(nullable: false),
                        Processador = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModeloMaquina", t => t.ModeloMaquina_Id, cascadeDelete: true)
                .Index(t => t.ModeloMaquina_Id);
            
            CreateTable(
                "dbo.ModeloMaquina",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ramal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.Int(nullable: false),
                        Numero = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sede",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Cidade = c.String(nullable: false, maxLength: 100),
                        Imagem = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nome, name: "IX_Sede_Nome");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Andar", "Sede_Id", "dbo.Sede");
            DropForeignKey("dbo.Mesa", "Ramal_Id", "dbo.Ramal");
            DropForeignKey("dbo.Mesa", "MaquinaPessoal_Id", "dbo.MaquinaPessoal");
            DropForeignKey("dbo.MaquinaPessoal", "Id", "dbo.Maquina");
            DropForeignKey("dbo.Maquina", "ModeloMaquina_Id", "dbo.ModeloMaquina");
            DropForeignKey("dbo.Mesa", "Colaborador_Id", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "GerenteId", "dbo.Usuario");
            DropForeignKey("dbo.Mesa", "Andar_Id", "dbo.Andar");
            DropIndex("dbo.Sede", "IX_Sede_Nome");
            DropIndex("dbo.Maquina", new[] { "ModeloMaquina_Id" });
            DropIndex("dbo.MaquinaPessoal", new[] { "Id" });
            DropIndex("dbo.Usuario", new[] { "GerenteId" });
            DropIndex("dbo.Usuario", "IX_Usuario_Login");
            DropIndex("dbo.Usuario", "IX_Usuario_Nome");
            DropIndex("dbo.Mesa", new[] { "Ramal_Id" });
            DropIndex("dbo.Mesa", new[] { "Andar_Id" });
            DropIndex("dbo.Mesa", new[] { "MaquinaPessoal_Id" });
            DropIndex("dbo.Mesa", new[] { "Colaborador_Id" });
            DropIndex("dbo.Andar", new[] { "Sede_Id" });
            DropTable("dbo.Sede");
            DropTable("dbo.Ramal");
            DropTable("dbo.ModeloMaquina");
            DropTable("dbo.Maquina");
            DropTable("dbo.MaquinaPessoal");
            DropTable("dbo.Usuario");
            DropTable("dbo.Mesa");
            DropTable("dbo.Andar");
        }
    }
}
