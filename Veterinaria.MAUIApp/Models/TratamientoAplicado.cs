using System.Text.Json.Serialization;

namespace Veterinaria.MAUIApp.Models
{
    public class TratamientoAplicado
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("citaId")]
        public long CitaId { get; set; }

        [JsonPropertyName("tratamientoId")]
        public long TratamientoId { get; set; }

        [JsonPropertyName("veterinarioId")]
        public long VeterinarioId { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; } = string.Empty;

        [JsonPropertyName("observaciones")]
        public string Observaciones { get; set; } = string.Empty;
    }
}
