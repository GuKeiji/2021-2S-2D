USE LOCADORA;
GO

INSERT INTO EMPRESA (nomeEmpresa)
VALUES ('Unidas'), ('Maestro');

INSERT INTO MARCA (nomeMarca)
VALUES ('VW'), ('GM');

INSERT INTO CLIENTE (nomeCliente)
VALUES ('Jeremias'), ('Augusto');

INSERT INTO MODELO (idMarca, nomeModelo)
VALUES (1,'Polo'), (2,'Celta');

INSERT INTO VEICULO (idModelo, idEmpresa, placa)
VALUES (2,1,'EEE'), (1,2,'AAA');

INSERT INTO ALUGUEL (idVeiculo, idCliente, dataAluguel, dataDevolucao)
VALUES (1,2,'03/08/2021', '13/08/2021'), (2,1,'04/08/2021', '14/08/2021');
