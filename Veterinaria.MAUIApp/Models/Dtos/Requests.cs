using System.Text.Json.Serialization;
using Veterinaria.MAUIApp.Models;
namespace Veterinaria.MAUIApp.Models.Dtos;

public class ServicioRequest
{
    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = string.Empty; // Valor inicial

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; } = string.Empty; // Valor inicial

    [JsonPropertyName("precioBase")]
    public decimal PrecioBase { get; set; }

    [JsonPropertyName("estado")]
    public EstadoServicio? Estado { get; set; }
}

public class ServicioEstadoRequest
{
    [JsonPropertyName("estado")]
    public EstadoServicio Estado { get; set; }
}
<<<<<<< HEAD
public class ServicioRes

{
    public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
}
=======

>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
public class MotivoRequest
{
    [JsonPropertyName("id")]
    public short Id { get; set; }

    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = string.Empty; // Valor inicial
}

public class MotivoServicioRequest
{
    [JsonPropertyName("motivoId")]
    public short MotivoId { get; set; }

    [JsonPropertyName("servicioId")]
    public long ServicioId { get; set; }
}