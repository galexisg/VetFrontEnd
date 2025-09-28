using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
    public class FacturaDTO
    {
        public long Id { get; set; }

        [JsonPropertyName("cliente_id")]
        public long ClienteId { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; } = string.Empty;

        [JsonPropertyName("total")]
        public decimal Total { get; set; }

        [JsonPropertyName("saldo")]
        public decimal Saldo { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime FechaCreacion { get; set; }
    }
}
