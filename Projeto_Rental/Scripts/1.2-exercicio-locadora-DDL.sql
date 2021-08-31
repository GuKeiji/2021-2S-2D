--CRIOU BANCO DE DADOS
CREATE DATABASE LOCADORA;
GO

--DEFINE BANCO DE DADOS A SER USADO
USE LOCADORA;
GO

--ALTER DATABASE PCLINICS MODIFY NAME = LOCADORA;

--CRIA TABELA EMPRESA
CREATE TABLE EMPRESA    (
 idEmpresa TINYINT PRIMARY KEY IDENTITY(1,1),
 nomeEmpresa VARCHAR(20) NOT NULL
 );
 GO

 CREATE TABLE MARCA(
 idMarca SMALLINT PRIMARY KEY IDENTITY(1,1),
 nomeMarca VARCHAR(20) NOT NULL
 );
 GO

 CREATE TABLE CLIENTE(
 idCliente INT PRIMARY KEY IDENTITY(1,1),
 nomeCliente VARCHAR(70) NOT NULL 
 );

 CREATE TABLE MODELO(
 idModelo SMALLINT PRIMARY KEY IDENTITY(1,1),
 idMarca SMALLINT FOREIGN KEY REFERENCES MARCA(idMarca),
 nomeModelo VARCHAR(20) NOT NULL
 );

 CREATE TABLE VEICULO(
 idVeiculo INT PRIMARY KEY IDENTITY(1,1),
 idEmpresa TINYINT FOREIGN KEY REFERENCES EMPRESA(idEmpresa),
 idModelo SMALLINT FOREIGN KEY REFERENCES MODELO(idModelo),
 placa VARCHAR(10) NOT NULL
 );
 GO

 CREATE TABLE ALUGUEL(
 idAluguel INT PRIMARY KEY IDENTITY(1,1),
 idCliente INT FOREIGN KEY REFERENCES CLIENTE(idCliente),
 idVeiculo INT FOREIGN KEY REFERENCES VEICULO(idVeiculo),
 dataAluguel DATE NOT NULL,
 dataDevolucao DATE NOT NULL
 );

 --ALTER TABLE ALUGUEL
 --DROP COLUMN dataDevolucao;

 --DROP TABLE ALUGUEL;