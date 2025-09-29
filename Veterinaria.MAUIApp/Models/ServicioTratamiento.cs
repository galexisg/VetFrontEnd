using System.Text.Json.Serialization;

namespace Veterinaria.MAUIApp.Models
{
  
    public class ServicioTratamiento
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("servicioId")]
        public long ServicioId { get; set; }

        [JsonPropertyName("tratamientoId")]
        public long TratamientoId { get; set; }

        [JsonPropertyName("activo")]
        public bool Activo { get; set; }
    }

    
}

