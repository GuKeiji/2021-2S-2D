using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório AluguelRepository
    /// </summary>
    interface IAluguelRepository
    {
        /// <summary>
        /// Lista todos os Alugueis
        /// </summary>
        /// <returns> Lista de Alugueis </returns>
        List<AluguelDomain> ListarTodos();
        
        /// <summary>
        /// Busca um aluguel pelo seu id
        /// </summary>
        /// <param name="idAluguel"> id do aluguel que vai ser buscado </param>
        /// <returns> O aluguel buscado </returns>
        AluguelDomain BuscarPorId(int idAluguel);

        /// <summary>
        /// Deleta um aluguel
        /// </summary>
        /// <param name="idAluguel"> id do aluguel que vai ser deletado </param>
        void Deletar(int idAluguel);
        
        /// <summary>
        /// Atualiza um aluguel
        /// </summary>
        /// <param name="aluguelAtualizado"> Objeto aluguelAtualizado com os novos dados atualizados </param>
        void AtualizarIdCorpo(AluguelDomain aluguelAtualizado);
        
        /// <summary>
        /// Insere um aluguel novo
        /// </summary>
        /// <param name="novoAluguel"> Objeto novoAluguel com os novos dados </param>
        void Inserir(AluguelDomain novoAluguel);
    }
}
