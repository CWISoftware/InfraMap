namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populandosedeeandares : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Sede(Nome,NomeCidade) VALUES ('Cwi - Sao Leo','Sao Leopoldo')");
            Sql("INSERT INTO Andar(Descricao,Sede_Id) VALUES ('Andar 1', 1)");
            Sql("INSERT INTO Andar(Descricao,Sede_Id) VALUES ('Andar 2', 1)");
            Sql("INSERT INTO Andar(Descricao,Sede_Id) VALUES ('Andar 3', 1)");
            Sql("INSERT INTO Andar(Descricao,Sede_Id) VALUES ('Andar 4', 1)");
            Sql("INSERT INTO Andar(Descricao,Sede_Id) VALUES ('Andar 5', 1)");
            Sql("INSERT INTO Andar(Descricao,Sede_Id) VALUES ('Andar 6', 1)");
        }

        public override void Down()
        {
            Sql("DELETE FROM Andar WHERE Id = 1");
            Sql("DELETE FROM Andar WHERE Id = 2");
            Sql("DELETE FROM Andar WHERE Id = 3");
            Sql("DELETE FROM Andar WHERE Id = 4");
            Sql("DELETE FROM Andar WHERE Id = 5");
            Sql("DELETE FROM Andar WHERE Id = 6");
            Sql("DELETE FROM Sede WHERE Id = 1");
        }
    }
}
