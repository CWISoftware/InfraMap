namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Populartabeladeandaresesede : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Andar(Descricao,Sede_Id) VALUES ('Primeiro Andar', 1)");
            Sql("INSERT INTO Andar(Descricao,Sede_Id) VALUES ('Segundo Andar', 1)");
            Sql("INSERT INTO Andar(Descricao,Sede_Id) VALUES ('Quarto Andar', 1)");
            Sql("INSERT INTO Andar(Descricao,Sede_Id) VALUES ('Quinto Andar', 1)");
            Sql("INSERT INTO Andar(Descricao,Sede_Id) VALUES ('Sexto Andar', 1)");
            Sql("INSERT INTO Sede(Nome,NomeCidade) VALUES ('Cwi - Caxias','Caxias')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Andar WHERE Id = 2");
            Sql("DELETE FROM Andar WHERE Id = 3");
            Sql("DELETE FROM Andar WHERE Id = 4");
            Sql("DELETE FROM Andar WHERE Id = 5");
            Sql("DELETE FROM Andar WHERE Id = 6");
            Sql("DELETE FROM Sede WHERE Id = 2");
        }
    }
}
