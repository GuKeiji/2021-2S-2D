using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class EmpresaDomain
    {
        [JsonIgnore]
        public int idEmpresa { get; set; }
        public string nomeEmpresa { get; set; }
    }
}
