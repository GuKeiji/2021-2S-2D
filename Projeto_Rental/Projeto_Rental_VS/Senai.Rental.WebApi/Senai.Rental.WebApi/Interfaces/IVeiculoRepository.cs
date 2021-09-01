using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório VeiculoRepository
    /// </summary>
   interface IVeiculoRepository
    {
        /// <summary>
        /// Lista todos os Veiculos
        /// </summary>
        /// <returns> Lista de Veiculos </returns>
        List<VeiculoDomain> ListarTodos();

        /// <summary>
        /// Busca um veiculo pelo seu id
        /// </summary>
        /// <param name="idVeiculo"> id do veiculo que vai ser buscado </param>
        /// <returns> O veiculo buscado </returns>
        VeiculoDomain BuscarPorId(int idVeiculo);

        /// <summary>
        /// Deleta um veiculo
        /// </summary>
        /// <param name="idVeiculo"> id do veiculo que vai ser deletado </param>
        void Deletar(int idVeiculo);

        /// <summary>
        /// Atualiza um veiculo
        /// </summary>
        /// <param name="veiculolAtualizado"> Objeto veiculolAtualizado com os novos dados atualizados </param>
        void AtualizarIdCorpo(VeiculoDomain veiculolAtualizado);

        /// <summary>
        /// Insere um veiculo novo
        /// </summary>
        /// <param name="novoVeiculo"> Objeto novoVeiculo com os novos dados </param>
        void Inserir(VeiculoDomain novoVeiculo);
    }
}
