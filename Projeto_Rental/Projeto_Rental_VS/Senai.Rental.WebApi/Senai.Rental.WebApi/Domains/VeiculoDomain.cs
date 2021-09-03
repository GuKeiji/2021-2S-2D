using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    /// <summary>
    /// Classe representa a entidade (tabela) VEICULO
    /// </summary>
    public class VeiculoDomain
    {
        [JsonIgnore]
        public int idVeiculo { get; set; }
        [JsonIgnore]
        public int idEmpresa { get; set; }
        [JsonIgnore]
        public int idModelo { get; set; }
        public string placa { get; set; }
        public ModeloDomain modelo { get; set; }
        public EmpresaDomain empresa { get; set; }
    }
}
