namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Andar", new[] { "Sede_Id" });
            AlterColumn("dbo.Andar", "Sede_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Andar", "Sede_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Andar", new[] { "Sede_Id" });
            AlterColumn("dbo.Andar", "Sede_Id", c => c.Int());
            CreateIndex("dbo.Andar", "Sede_Id");
        }
    }
}
