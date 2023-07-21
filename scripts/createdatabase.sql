-- Verifica se o banco de dados existe
IF DB_ID('myfinance') IS NULL
BEGIN
    -- Cria o banco de dados se ele não existir
    CREATE DATABASE myfinance;
END
GO
	USE myfinance;
GO

IF OBJECT_ID('dbo.PlanoConta', 'U') IS NULL
BEGIN
	CREATE TABLE dbo.PlanoConta(
		Id UNIQUEIDENTIFIER PRIMARY KEY,
		Descricao VARCHAR(50) NOT NULL,
		Tipo INT NOT NULL
	);


	INSERT INTO dbo.PlanoConta(Id,Descricao, Tipo) VALUES(NEWID(),'Combustível', 0)
	INSERT INTO dbo.PlanoConta(Id,Descricao, Tipo) VALUES(NEWID(),'Salário', 1)
	INSERT INTO dbo.PlanoConta(Id,Descricao, Tipo) VALUES(NEWID(),'Alimentação', 0)
	INSERT INTO dbo.PlanoConta(Id,Descricao, Tipo) VALUES(NEWID(),'Impostos', 0)
	INSERT INTO dbo.PlanoConta(Id,Descricao, Tipo) VALUES(NEWID(),'Água', 0)
	INSERT INTO dbo.PlanoConta(Id,Descricao, Tipo) VALUES(NEWID(),'Luz', 0)
	INSERT INTO dbo.PlanoConta(Id,Descricao, Tipo) VALUES(NEWID(),'Internet', 0)
	END
GO