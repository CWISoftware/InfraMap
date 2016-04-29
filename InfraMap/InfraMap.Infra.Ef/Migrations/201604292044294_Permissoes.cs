namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Permissoes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsuarioPermissao", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioPermissao", "Permissao_Id", "dbo.Permissao");
            DropIndex("dbo.UsuarioPermissao", new[] { "Usuario_Id" });
            DropIndex("dbo.UsuarioPermissao", new[] { "Permissao_Id" });
            DropTable("dbo.Permissao");
            DropTable("dbo.UsuarioPermissao");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsuarioPermissao",
                c => new
                    {
                        Usuario_Id = c.Int(nullable: false),
                        Permissao_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_Id, t.Permissao_Id });
            
            CreateTable(
                "dbo.Permissao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UsuarioPermissao", "Permissao_Id");
            CreateIndex("dbo.UsuarioPermissao", "Usuario_Id");
            AddForeignKey("dbo.UsuarioPermissao", "Permissao_Id", "dbo.Permissao", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UsuarioPermissao", "Usuario_Id", "dbo.Usuario", "Id", cascadeDelete: true);
        }
    }
}
