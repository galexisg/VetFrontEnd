using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Veterinaria.MAUIApp.Models;

public class BloqueHorarioRequest
{
    [JsonPropertyName("inicio")]
    [Required(ErrorMessage = "La hora de inicio es requerida.")]
    public string Inicio { get; set; }

    [JsonPropertyName("fin")]
    [Required(ErrorMessage = "La hora de fin es requerida.")]
    public string Fin { get; set; }

    [JsonPropertyName("activo")]
    public bool Activo { get; set; } = true;
}