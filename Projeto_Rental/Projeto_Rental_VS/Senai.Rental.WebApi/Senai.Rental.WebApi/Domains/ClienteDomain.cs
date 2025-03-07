﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    /// <summary>
    /// Classe representa a entidade (tabela) CLIENTE
    /// </summary>
    public class ClienteDomain
    {
        [JsonIgnore]
        public int idCliente { get; set; }
        public string nomeCliente { get; set; }
        public string sobrenomeCliente { get; set; }
    }
}
