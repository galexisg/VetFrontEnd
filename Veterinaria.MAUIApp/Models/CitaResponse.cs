using System.Text.Json.Serialization;

namespace Veterinaria.MAUIApp.Models
{
    public class CitaResponse
    {
        [JsonPropertyName("citaId")]
        public long CitaId { get; set; }

        [JsonPropertyName("mascotaId")]
        public int MascotaId { get; set; }

        [JsonPropertyName("usuarioId")]
        public int UsuarioId { get; set; }

        [JsonPropertyName("veterinarioId")]
        public int VeterinarioId { get; set; }

        [JsonPropertyName("motivoId")]
        public int MotivoId { get; set; }

        [JsonPropertyName("citaEstadoId")]
        public int CitaEstadoId { get; set; }

        [JsonPropertyName("facturaId")]
        public long? FacturaId { get; set; }

        [JsonPropertyName("tipo")]
        public string Tipo { get; set; } = "Normal";

        [JsonPropertyName("fechaHora")]
        public DateTime FechaHora { get; set; }

        [JsonPropertyName("observaciones")]
        public string? Observaciones { get; set; }
    }
}
