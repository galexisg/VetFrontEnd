using System.Text.Json.Serialization;

namespace Veterinaria.MAUIApp.Models
{
    // Hace que System.Text.Json (de)serialice "ACTIVO"/"INACTIVO" como texto
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EstadoServicio
    {
        ACTIVO,
        INACTIVO
    }
}