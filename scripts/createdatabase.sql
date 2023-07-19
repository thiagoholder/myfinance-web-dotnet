/* Criar Banco de Dados */
CREATE DATABASE myfinance

USE myfinance

/* Estrutura do Banco de dados */
CREATE TABLE PlanoConta(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	Descricao VARCHAR(50) NOT NULL,
	Tipo INT NOT NULL
);



/* Inserir primeira carga de dados */
INSERT INTO PlanoConta(Id,Descricao, Tipo) VALUES(NEWID(),'Combustível', 0)
INSERT INTO PlanoConta(Id,Descricao, Tipo) VALUES(NEWID(),'Salário', 1)
INSERT INTO PlanoConta(Id,Descricao, Tipo) VALUES(NEWID(),'Alimentação', 0)
INSERT INTO PlanoConta(Id,Descricao, Tipo) VALUES(NEWID(),'Impostos', 0)
INSERT INTO PlanoConta(Id,Descricao, Tipo) VALUES(NEWID(),'Água', 0)
INSERT INTO PlanoConta(Id,Descricao, Tipo) VALUES(NEWID(),'Luz', 0)
INSERT INTO PlanoConta(Id,Descricao, Tipo) VALUES(NEWID(),'Internet', 0)