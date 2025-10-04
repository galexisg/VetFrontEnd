using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
    public class MovimientoInventario
    {
        // El DTO de Java devuelve 'id'
        [JsonPropertyName("id")]
        public int Id { get; set; }

        // El DTO de Java devuelve 'tipo' como String (ENTRADA o SALIDA)
        [JsonPropertyName("tipo")]
        public string Tipo { get; set; } = string.Empty;

        // Fecha del movimiento (mapeado de LocalDateTime/Date en Java)
        [JsonPropertyName("fecha")]
        public DateTime Fecha { get; set; }

        // Observaciones del movimiento
        [JsonPropertyName("observacion")]
        public string Observacion { get; set; } = string.Empty;
    }
}
