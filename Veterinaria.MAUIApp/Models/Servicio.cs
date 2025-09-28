using System;
using System.Text.Json.Serialization;

namespace Veterinaria.MAUIApp.Models
{
    public class Servicio
    {
        public long Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal? PrecioBase { get; set; }
        public EstadoServicio Estado { get; set; } = EstadoServicio.ACTIVO;

        [JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
}
