namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterandoColunaGerente_Id_Null : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Usuario", new[] { "Gerente_Id" });
            AlterColumn("dbo.Andar", "Descricao", c => c.String());
            AlterColumn("dbo.Usuario", "Nome", c => c.String());
            AlterColumn("dbo.Usuario", "Login", c => c.String());
            AlterColumn("dbo.Usuario", "Senha", c => c.String());
            AlterColumn("dbo.Usuario", "Gerente_Id", c => c.Int());
            AlterColumn("dbo.Maquina", "Nome", c => c.String());
            AlterColumn("dbo.Maquina", "Tipo", c => c.String());
            AlterColumn("dbo.Ramal", "Tipo", c => c.String());
            AlterColumn("dbo.Ramal", "Numero", c => c.String());
            AlterColumn("dbo.Sede", "Nome", c => c.String());
            AlterColumn("dbo.Sede", "NomeCidade", c => c.String());
            CreateIndex("dbo.Usuario", "Gerente_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Usuario", new[] { "Gerente_Id" });
            AlterColumn("dbo.Sede", "NomeCidade", c => c.String(nullable: false));
            AlterColumn("dbo.Sede", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Ramal", "Numero", c => c.String(nullable: false));
            AlterColumn("dbo.Ramal", "Tipo", c => c.String(nullable: false));
            AlterColumn("dbo.Maquina", "Tipo", c => c.String(nullable: false));
            AlterColumn("dbo.Maquina", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "Gerente_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuario", "Senha", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Andar", "Descricao", c => c.String(nullable: false));
            CreateIndex("dbo.Usuario", "Gerente_Id");
        }
    }
}
