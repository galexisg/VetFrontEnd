using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
    public class Tratamiento
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        [JsonPropertyName("precioSugerido")]
        public decimal PrecioSugerido { get; set; }

        [JsonPropertyName("duracionDias")]
        public int DuracionDias { get; set; }

        [JsonPropertyName("frecuencia")]
        public string Frecuencia { get; set; } = string.Empty;

        [JsonPropertyName("via")]
        public string Via { get; set; } = string.Empty;

        [JsonPropertyName("activo")]
        public bool Activo { get; set; }
    }
}