using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class ModeloDomain
    {
        [JsonIgnore]
        public int idModelo { get; set; }
        [JsonIgnore]
        public int idMarca { get; set; }
        public string nomeModelo { get; set; }
        public MarcaDomain marca { get; set; }
    }
}
