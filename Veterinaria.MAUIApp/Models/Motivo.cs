using System.Text.Json.Serialization;
namespace Veterinaria.MAUIApp.Models;

public class Motivo
{
    [JsonPropertyName("id")]
    public short Id { get; set; }

    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = string.Empty; // Valor inicial para evitar advertencia
}