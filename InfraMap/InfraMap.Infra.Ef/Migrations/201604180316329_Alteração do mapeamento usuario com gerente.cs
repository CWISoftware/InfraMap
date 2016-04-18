namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteraçãodomapeamentousuariocomgerente : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Usuario", name: "Gerente_Id", newName: "GerenteId");
            RenameIndex(table: "dbo.Usuario", name: "IX_Gerente_Id", newName: "IX_GerenteId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Usuario", name: "IX_GerenteId", newName: "IX_Gerente_Id");
            RenameColumn(table: "dbo.Usuario", name: "GerenteId", newName: "Gerente_Id");
        }
    }
}
