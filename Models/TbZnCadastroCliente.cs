using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CadastroClienteZerrenner.Models
{
    public partial class TbZnCadastroCliente
    {
        [JsonProperty("IdCliente")]
        public int IdCadastroCliente { get; set; }
        [JsonProperty("nomeCliente")]

        public string Nome { get; set; }

        [JsonProperty("cpfCliente")]
        public string Cpf { get; set; }
        [JsonProperty("profissaoCliente")]

        public string Profissao { get; set; }
        [JsonProperty("telefoneCliente")]

        public string Telefone { get; set; }
        [JsonProperty("dataCriacaoCliente")]
        public DateTime? DataCriacao { get; set; }
    }
}
