using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório ClienteRepository
    /// </summary>
    interface IClienteRepository
    {
        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        /// <returns> Lista de Clientes </returns>
        List<ClienteDomain> ListarTodos();
        /// <summary>
        /// Busca um cliente pelo seu id
        /// </summary>
        /// <param name="idCliente"> id do cliente que vai ser buscado </param>
        /// <returns> O cliente buscado </returns>
        ClienteDomain BuscarPorId(int idCliente);
        /// <summary>
        /// Deleta um cliente
        /// </summary>
        /// <param name="idCliente"> id do cliente que vai ser deletado </param>
        void Deletar(int idCliente);
        /// <summary>
        /// Atualiza um cliente
        /// </summary>
        /// <param name="clienteAtualizado"> Objeto clienteAtualizado com os novos dados atualizados </param>
        void AtualizarIdCorpo(ClienteDomain clienteAtualizado);
        /// <summary>
        /// Insere um cliente novo
        /// </summary>
        /// <param name="novoCliente"> Objeto novoCliente com os novos dados </param>
        void Inserir(ClienteDomain novoCliente);
    }
}
