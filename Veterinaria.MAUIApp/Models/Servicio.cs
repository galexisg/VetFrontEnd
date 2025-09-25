using System.Text.Json.Serialization;
namespace Veterinaria.MAUIApp.Models;

public class Servicio
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = string.Empty; // Valor inicial

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; } = string.Empty; // Valor inicial

    [JsonPropertyName("precioBase")]
    public decimal PrecioBase { get; set; }

    [JsonPropertyName("estado")]
    public EstadoServicio Estado { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }
   
    
   
}