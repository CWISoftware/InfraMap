namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Andar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Sede_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sede", t => t.Sede_Id, cascadeDelete: true)
                .Index(t => t.Sede_Id);
            
            CreateTable(
                "dbo.Mesa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        Colaborador_Id = c.Int(),
                        Maquina_Id = c.Int(),
                        Ramal_Id = c.Int(),
                        Andar_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Colaborador_Id)
                .ForeignKey("dbo.Maquina", t => t.Maquina_Id)
                .ForeignKey("dbo.Ramal", t => t.Ramal_Id)
                .ForeignKey("dbo.Andar", t => t.Andar_Id, cascadeDelete: true)
                .Index(t => t.Colaborador_Id)
                .Index(t => t.Maquina_Id)
                .Index(t => t.Ramal_Id)
                .Index(t => t.Andar_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Login = c.String(),
                        Senha = c.String(),
                        Gerente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Gerente_Id)
                .Index(t => t.Gerente_Id);
            
            CreateTable(
                "dbo.Permissao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Maquina",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ramal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                        Numero = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sede",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        NomeCidade = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsuarioPermissao",
                c => new
                    {
                        Usuario_Id = c.Int(nullable: false),
                        Permissao_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_Id, t.Permissao_Id })
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id, cascadeDelete: true)
                .ForeignKey("dbo.Permissao", t => t.Permissao_Id, cascadeDelete: true)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Permissao_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Andar", "Sede_Id", "dbo.Sede");
            DropForeignKey("dbo.Mesa", "Andar_Id", "dbo.Andar");
            DropForeignKey("dbo.Mesa", "Ramal_Id", "dbo.Ramal");
            DropForeignKey("dbo.Mesa", "Maquina_Id", "dbo.Maquina");
            DropForeignKey("dbo.Mesa", "Colaborador_Id", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioPermissao", "Permissao_Id", "dbo.Permissao");
            DropForeignKey("dbo.UsuarioPermissao", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "Gerente_Id", "dbo.Usuario");
            DropIndex("dbo.UsuarioPermissao", new[] { "Permissao_Id" });
            DropIndex("dbo.UsuarioPermissao", new[] { "Usuario_Id" });
            DropIndex("dbo.Usuario", new[] { "Gerente_Id" });
            DropIndex("dbo.Mesa", new[] { "Andar_Id" });
            DropIndex("dbo.Mesa", new[] { "Ramal_Id" });
            DropIndex("dbo.Mesa", new[] { "Maquina_Id" });
            DropIndex("dbo.Mesa", new[] { "Colaborador_Id" });
            DropIndex("dbo.Andar", new[] { "Sede_Id" });
            DropTable("dbo.UsuarioPermissao");
            DropTable("dbo.Sede");
            DropTable("dbo.Ramal");
            DropTable("dbo.Maquina");
            DropTable("dbo.Permissao");
            DropTable("dbo.Usuario");
            DropTable("dbo.Mesa");
            DropTable("dbo.Andar");
        }
    }
}
