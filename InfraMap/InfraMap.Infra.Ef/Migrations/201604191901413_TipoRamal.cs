namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class TipoRamal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ramal", "Tipo", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Ramal", "Tipo", c => c.String(nullable: false, maxLength: 25));
        }
    }
}
