namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Retiradocamposenhadousuario : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuario", "Senha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "Senha", c => c.String(nullable: false, maxLength: 64));
        }
    }
}
