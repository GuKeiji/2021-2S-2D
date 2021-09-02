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
                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public AluguelDomain BuscarPorId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idAluguel, idCliente, idVeiculo, dataAluguel, dataDevolucao FROM ALUGUEL WHERE idAluguel = @idAluguel";

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
                            idAluguel = Convert.ToInt32(rdr[0]),
                            idCliente = Convert.ToInt32(rdr[1]),
                            idVeiculo = Convert.ToInt32(rdr[2]),
                            dataAluguel = Convert.ToDateTime(rdr[3]),
                            dataDevolucao = Convert.ToDateTime(rdr[4])
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
                string querySelectAll = "SELECT idAluguel, idCliente, idVeiculo, dataAluguel, dataDevolucao FROM ALUGUEL";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        AluguelDomain aluguel = new AluguelDomain
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            idCliente = Convert.ToInt32(rdr[1]),
                            idVeiculo = Convert.ToInt32(rdr[2]),
                            dataAluguel = Convert.ToDateTime(rdr[3]),
                            dataDevolucao = Convert.ToDateTime(rdr[4])
                        };

                        listaAlugueis.Add(aluguel);
                    }
                }
            }
            return listaAlugueis;
        }
    }
}
