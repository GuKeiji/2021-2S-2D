using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class MarcaDomain
    {
        [JsonIgnore]
        public int idMarca { get; set; }
        public string nomeMarca { get; set; }
    }
}
