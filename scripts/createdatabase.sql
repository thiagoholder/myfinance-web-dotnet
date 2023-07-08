/* Criar Banco de Dados */
CREATE DATABASE myfinance

USE myfinance

/* Estrutura do Banco de dados */
CREATE TABLE planoconta(
	id int IDENTITY NOT NULL,
	descricao VARCHAR(50) NOT NULL,
	tipo CHAR(1),
	PRIMARY KEY (id)
);



/* Inserir primeira carga de dados */
INSERT INTO planoconta(descricao, tipo) VALUES('Combustível', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Salário', 'R')
INSERT INTO planoconta(descricao, tipo) VALUES('Alimentação', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Impostos', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Água', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Luz', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Internet', 'D')