INSERT INTO Sede (Cidade, Nome, Imagem)
VALUES ('S�o Leopoldo', 'CWISL', 'cwi-sl.jpg')

INSERT INTO Andar (Descricao, Sede_Id)
VALUES ('1� Andar', 1)
INSERT INTO Andar (Descricao, Sede_Id)
VALUES ('2� Andar', 1)
INSERT INTO Andar (Descricao, Sede_Id)
VALUES ('3� Andar', 1)
INSERT INTO Andar (Descricao, Sede_Id)
VALUES ('4� Andar', 1)
INSERT INTO Andar (Descricao, Sede_Id)
VALUES ('5� Andar', 1)
INSERT INTO Andar (Descricao, Sede_Id)
VALUES ('6� Andar', 1)

delete from Mesa

--5� andar
declare @i int = 1;
while @i < 109
begin
   insert into Mesa (Id, Andar_Id) values (@i, 5)
   set @i = @i + 1;
end;

--4� andar
while @i < 217
begin
   insert into Mesa (Id, Andar_Id) values (@i, 4)
   set @i = @i + 1;
end;

--3� andar
while @i < 310
begin
   insert into Mesa (Id, Andar_Id) values (@i, 3)
   set @i = @i + 1;
end;