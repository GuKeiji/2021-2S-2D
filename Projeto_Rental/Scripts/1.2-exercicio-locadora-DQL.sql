USE T_Rental;
GO

SELECT * FROM EMPRESA
SELECT * FROM MARCA
SELECT * FROM CLIENTE
SELECT * FROM MODELO
SELECT * FROM VEICULO
SELECT * FROM ALUGUEL

-- listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro
SELECT A.dataAluguel, 
	   A.dataDevolucao, 
	   C.nomeCliente, 
	   M.nomeModelo
  FROM ALUGUEL A
 INNER JOIN CLIENTE C
    ON A.idCliente = C.idCliente
 INNER JOIN VEICULO V
    ON A.idVeiculo = V.idVeiculo
 INNER JOIN MODELO M
    ON V.idModelo = M.idModelo;

--listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro
SELECT A.dataAluguel, 
	   A.dataDevolucao, 
	   C.nomeCliente, 
	   M.nomeModelo
  FROM ALUGUEL A
 INNER JOIN CLIENTE C
    ON A.idCliente = C.idCliente
 INNER JOIN VEICULO V
    ON A.idVeiculo = V.idVeiculo
 INNER JOIN MODELO M
    ON V.idModelo = M.idModelo
 WHERE C.nomeCliente = 'Jeremias';

/*
SELECT ALUGUEL.idAluguel, 
       ALUGUEL.dataAluguel,  
	   ALUGUEL.dataDevolucao, 
	   CLIENTE.nomeCliente, 
	   MODELO.nomeModelo 
  FROM CLIENTE, MODELO, VEICULO
 WHERE CLIENTE.idCliente = ALUGUEL.idCliente
   and ALUGUEL.idVeiculo = VEICULO.idVeiculo
   and MODELO.idModelo   = VEICULO.idModelo
*/
