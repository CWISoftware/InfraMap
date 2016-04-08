namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionadocornousuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Cor", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Cor");
        }
    }
}
