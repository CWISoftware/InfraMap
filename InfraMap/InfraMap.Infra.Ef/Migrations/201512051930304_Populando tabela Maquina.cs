namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulandotabelaMaquina : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Maquina (Nome, Tipo) VALUES ('D225', 'Optiplex 380')");
            Sql("INSERT INTO Maquina (Nome, Tipo) VALUES ('D230', 'Optiplex 330')");
            Sql("INSERT INTO Maquina (Nome, Tipo) VALUES ('D275', 'Optiplex 3020')");
            Sql("INSERT INTO Maquina (Nome, Tipo) VALUES ('D325', 'Optiplex 390')");
            Sql("INSERT INTO Maquina (Nome, Tipo) VALUES ('D415', 'Optiplex 3010')");
            Sql("INSERT INTO Maquina (Nome, Tipo) VALUES ('D773', 'Optiplex 7010')");
            Sql("INSERT INTO Maquina (Nome, Tipo) VALUES ('D147', 'Notebook')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Maquina WHERE Id = 2;");
            Sql("DELETE FROM Maquina WHERE Id = 3;");
            Sql("DELETE FROM Maquina WHERE Id = 4;");
            Sql("DELETE FROM Maquina WHERE Id = 5;");
            Sql("DELETE FROM Maquina WHERE Id = 6;");
            Sql("DELETE FROM Maquina WHERE Id = 7;");
            Sql("DELETE FROM Maquina WHERE Id = 8;");
        }
    }
}
