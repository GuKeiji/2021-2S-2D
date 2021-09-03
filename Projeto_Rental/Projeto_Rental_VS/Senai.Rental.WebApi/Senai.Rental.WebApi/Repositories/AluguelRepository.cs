using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private string stringConexao = @"Data Source=PC-GAMER-GUKEIJ\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";
        //private string stringConexao = @"Data Source=NOTE0113G2\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=Senai@132";
        public void AtualizarIdCorpo(AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateBody = "UPDATE ALUGUEL SET idCliente = @idCliente, idVeiculo = @idVeiculo, dataAluguel = @dataAluguel, dataDevolucao = @dataDevolucao WHERE idAluguel = @idAluguel";
                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", aluguelAtualizado.idVeiculo);
                    cmd.Parameters.AddWithValue("@dataAluguel", aluguelAtualizado.dataAluguel);
                    cmd.Parameters.AddWithValue("@dataDevolucao", aluguelAtualizado.dataDevolucao);
                    cmd.Parameters.AddWithValue("@idCliente", aluguelAtualizado.idCliente);
                    cmd.Parameters.AddWithValue("@idAluguel", aluguelAtualizado.idAluguel);
                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public AluguelDomain BuscarPorId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = @"SELECT A.dataAluguel, 
                                                   A.dataDevolucao, 
	                                               C.nomeCliente, 
                                                   C.sobrenomeCliente,
                                                   V.placa,
	                                               M.nomeModelo,
	                                               MA.nomeMarca
                                              FROM ALUGUEL A
                                             INNER JOIN CLIENTE C
                                                ON A.idCliente = C.idCliente
                                             INNER JOIN VEICULO V
                                                ON A.idVeiculo = V.idVeiculo
                                             INNER JOIN MODELO M
                                                ON V.idModelo = M.idModelo
                                             INNER JOIN MARCA MA
                                                ON M.idMarca = MA.idMarca
                                             WHERE idAluguel = @idAluguel";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        AluguelDomain aluguelBuscado = new AluguelDomain
                        {
                            dataAluguel = Convert.ToDateTime(rdr[0]),
                            dataDevolucao = Convert.ToDateTime(rdr[1]),

                            cliente = new ClienteDomain
                            {
                                nomeCliente = rdr[2].ToString(),
                                sobrenomeCliente = rdr[3].ToString()                                
                            },

                            veiculo = new VeiculoDomain
                            {
                                placa = rdr[4].ToString(),
                                modelo = new ModeloDomain
                                {
                                    nomeModelo = rdr[5].ToString(),
                                    marca = new MarcaDomain
                                    {
                                        nomeMarca = rdr[6].ToString()
                                    }
                                }
                            }
                        };
                        return aluguelBuscado;
                    }
                    return null;
                }
            }
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @idAluguel";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Inserir(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO ALUGUEL (idCliente,idVeiculo,dataAluguel,dataDevolucao) VALUES (@idCliente,@idVeiculo,@dataAluguel,@dataDevolucao)";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);
                    cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.idVeiculo);
                    cmd.Parameters.AddWithValue("@dataAluguel", novoAluguel.dataAluguel);
                    cmd.Parameters.AddWithValue("@dataDevolucao", novoAluguel.dataDevolucao);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAlugueis = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = @"SELECT A.dataAluguel, 
                                                   A.dataDevolucao, 
	                                               C.nomeCliente, 
                                                   C.sobrenomeCliente,
                                                   V.placa,
	                                               M.nomeModelo,
	                                               MA.nomeMarca
                                              FROM ALUGUEL A
                                             INNER JOIN CLIENTE C
                                                ON A.idCliente = C.idCliente
                                             INNER JOIN VEICULO V
                                                ON A.idVeiculo = V.idVeiculo
                                             INNER JOIN MODELO M
                                                ON V.idModelo = M.idModelo
                                             INNER JOIN MARCA MA
                                                ON M.idMarca = MA.idMarca";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        AluguelDomain aluguel = new AluguelDomain
                        {
                            dataAluguel = Convert.ToDateTime(rdr[0]),
                            dataDevolucao = Convert.ToDateTime(rdr[1]),

                            cliente = new ClienteDomain
                            {
                                nomeCliente = rdr[2].ToString(),
                                sobrenomeCliente = rdr[3].ToString()
                            },

                            veiculo = new VeiculoDomain
                            {
                                placa = rdr[4].ToString(),
                                modelo = new ModeloDomain
                                {
                                    nomeModelo = rdr[5].ToString(),
                                    marca = new MarcaDomain
                                    {
                                        nomeMarca = rdr[6].ToString()
                                    }
                                }
                            }
                        };

                        listaAlugueis.Add(aluguel);
                    }
                }
            }
            return listaAlugueis;
        }
    }
}
