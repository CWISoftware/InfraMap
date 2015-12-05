namespace InfraMap.Infraestrutura.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Populartabelaramal : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Ramal (Tipo, Numero) VALUES ('Analogico','302')");
            Sql("INSERT INTO Ramal (Tipo, Numero) VALUES ('Digital','407')");
            Sql("INSERT INTO Ramal (Tipo, Numero) VALUES ('Digital','906')");
            Sql("INSERT INTO Ramal (Tipo, Numero) VALUES ('Digital','430')");
            Sql("INSERT INTO Ramal (Tipo, Numero) VALUES ('Analogico','137')");
            Sql("INSERT INTO Ramal (Tipo, Numero) VALUES ('Analogico','215')");
            Sql("INSERT INTO Ramal (Tipo, Numero) VALUES ('Digital','666')");
            Sql("INSERT INTO Ramal (Tipo, Numero) VALUES ('Analogico','777')");
            Sql("INSERT INTO Ramal (Tipo, Numero) VALUES ('Digital','204')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Ramal WHERE Id = 1");
            Sql("DELETE FROM Ramal WHERE Id = 2");
            Sql("DELETE FROM Ramal WHERE Id = 3");
            Sql("DELETE FROM Ramal WHERE Id = 4");
            Sql("DELETE FROM Ramal WHERE Id = 5");
            Sql("DELETE FROM Ramal WHERE Id = 6");
            Sql("DELETE FROM Ramal WHERE Id = 7");
            Sql("DELETE FROM Ramal WHERE Id = 8");
            Sql("DELETE FROM Ramal WHERE Id = 9");
        }
    }
}
