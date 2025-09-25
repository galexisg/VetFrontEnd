using System.Text.Json.Serialization;
using System;

namespace Veterinaria.MAUIApp.Models;

public class BloqueHorario
{
    [JsonPropertyName("bloqueHorarioId")]
    public int BloqueHorarioId { get; set; }

    [JsonPropertyName("inicio")]
    public TimeSpan Inicio { get; set; }

    [JsonPropertyName("fin")]
    public TimeSpan Fin { get; set; }

    [JsonPropertyName("activo")]
    public bool Activo { get; set; }
}