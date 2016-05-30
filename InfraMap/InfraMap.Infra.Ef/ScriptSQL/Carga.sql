INSERT INTO Sede (Cidade, Nome, Imagem)
VALUES ('São Leopoldo', 'CWISL', 'cwi-sl.jpg')

INSERT INTO Sede (Cidade, Nome, Imagem)
VALUES ('Porto Alegre','CWICG','cwi-poa-cg.jpg')

INSERT INTO Sede (Cidade, Nome, Imagem)
VALUES ('São Paulo','CWISP','cwi-sp.jpg')

INSERT INTO Andar (Descricao, Sede_Id)
VALUES ('1º Andar', 1)
INSERT INTO Andar (Descricao, Sede_Id)
VALUES ('2º Andar', 1)
INSERT INTO Andar (Descricao, Sede_Id)
VALUES ('3º Andar', 1)
INSERT INTO Andar (Descricao, Sede_Id)
VALUES ('4º Andar', 1)
INSERT INTO Andar (Descricao, Sede_Id)
VALUES ('5º Andar', 1)
INSERT INTO Andar (Descricao, Sede_Id)
VALUES ('6º Andar', 1)

INSERT INTO Andar (Descricao, Sede_Id)
VALUES ('1º Andar',2)
INSERT INTO Andar (Descricao, Sede_Id)
VALUES ('1º Andar',3)

delete from Mesa

--5º andar
declare @i int = 1;
while @i < 109
begin
   insert into Mesa (Id, Andar_Id,PontoEletrico,PontoLogico1) values (@i, 5,'','')
   set @i = @i + 1;
end;

--4º andar
while @i < 217
begin
   insert into Mesa (Id, Andar_Id,PontoEletrico,PontoLogico1) values (@i, 4,'','')
   set @i = @i + 1;
end;

--3º andar
while @i < 310
begin
   insert into Mesa (Id, Andar_Id,PontoEletrico,PontoLogico1) values (@i, 3,'','')
   set @i = @i + 1;
end;