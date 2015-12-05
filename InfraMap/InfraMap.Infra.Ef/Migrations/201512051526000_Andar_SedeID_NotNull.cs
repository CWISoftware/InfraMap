namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Andar_SedeID_NotNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Andar", "Sede_Id", "dbo.Sede");
            DropIndex("dbo.Andar", new[] { "Sede_Id" });
            AlterColumn("dbo.Andar", "Sede_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Andar", "Sede_Id");
            AddForeignKey("dbo.Andar", "Sede_Id", "dbo.Sede", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Andar", "Sede_Id", "dbo.Sede");
            DropIndex("dbo.Andar", new[] { "Sede_Id" });
            AlterColumn("dbo.Andar", "Sede_Id", c => c.Int());
            CreateIndex("dbo.Andar", "Sede_Id");
            AddForeignKey("dbo.Andar", "Sede_Id", "dbo.Sede", "Id");
        }
    }
}
