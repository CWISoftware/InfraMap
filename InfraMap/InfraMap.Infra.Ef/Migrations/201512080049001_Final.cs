namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Andar", "Descricao", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Usuario", "Nome", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Usuario", "Login", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Usuario", "Senha", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Permissao", "Texto", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Maquina", "Nome", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Maquina", "Tipo", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Ramal", "Tipo", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Ramal", "Numero", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Sede", "Nome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Sede", "NomeCidade", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Usuario", "Nome", name: "IX_Usuario_Nome");
            CreateIndex("dbo.Usuario", "Login", unique: true, name: "IX_Usuario_Login");
            CreateIndex("dbo.Sede", "Nome", name: "IX_Sede_Nome");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Sede", "IX_Sede_Nome");
            DropIndex("dbo.Usuario", "IX_Usuario_Login");
            DropIndex("dbo.Usuario", "IX_Usuario_Nome");
            AlterColumn("dbo.Sede", "NomeCidade", c => c.String());
            AlterColumn("dbo.Sede", "Nome", c => c.String());
            AlterColumn("dbo.Ramal", "Numero", c => c.String());
            AlterColumn("dbo.Ramal", "Tipo", c => c.String());
            AlterColumn("dbo.Maquina", "Tipo", c => c.String());
            AlterColumn("dbo.Maquina", "Nome", c => c.String());
            AlterColumn("dbo.Permissao", "Texto", c => c.String());
            AlterColumn("dbo.Usuario", "Senha", c => c.String());
            AlterColumn("dbo.Usuario", "Login", c => c.String());
            AlterColumn("dbo.Usuario", "Nome", c => c.String());
            AlterColumn("dbo.Andar", "Descricao", c => c.String());
        }
    }
}
