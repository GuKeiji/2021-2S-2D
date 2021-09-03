using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    /// <summary>
    /// Classe representa a entidade (tabela) ALUGUEL
    /// </summary>
    public class AluguelDomain
    {
        [JsonIgnore]
        public int idAluguel { get; set; }
        [JsonIgnore]
        public int idCliente { get; set; }
        [JsonIgnore]
        public int idVeiculo { get; set; }
        public DateTime dataAluguel { get; set; }
        public DateTime dataDevolucao { get; set; }
        public ClienteDomain cliente { get; set; }
        public VeiculoDomain veiculo { get; set; }
    }
}
