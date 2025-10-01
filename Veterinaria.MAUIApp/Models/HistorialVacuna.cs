using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Veterinaria.MAUIApp.Models
{
    public class HistorialVacuna
    {
        [JsonPropertyName("historialVacunaId")]
        public int HistorialVacunaId { get; set; }

        [JsonPropertyName("mascotaId")]
        [Required(ErrorMessage = "La mascota es obligatoria.")]
        public int MascotaId { get; set; }

        [JsonPropertyName("nombreMascota")]
        public string NombreMascota { get; set; } = string.Empty;

        [JsonPropertyName("vacunaId")]
        [Required(ErrorMessage = "La vacuna es obligatoria.")]
        public int VacunaId { get; set; }

        [JsonPropertyName("nombreVacuna")]
        public string NombreVacuna { get; set; } = string.Empty;

        [JsonPropertyName("fechaAplicacion")]
        [Required(ErrorMessage = "La fecha de aplicación es obligatoria.")]
        public DateTime FechaAplicacion { get; set; }

        [JsonPropertyName("proximaDosis")]
        public DateTime? ProximaDosis { get; set; }

        [JsonPropertyName("observaciones")]
        public string Observaciones { get; set; } = string.Empty;

        [JsonPropertyName("estado")]
        public string Estado { get; set; } = "Activo";
    }

    public class HistorialVacunaReq
    {
        [Required(ErrorMessage = "La mascota es obligatoria.")]
        public int MascotaId { get; set; }

        [Required(ErrorMessage = "La vacuna es obligatoria.")]
        public int VacunaId { get; set; }

        [Required(ErrorMessage = "La fecha de aplicación es obligatoria.")]
        public DateTime FechaAplicacion { get; set; }

        public DateTime? ProximaDosis { get; set; }

        public string Observaciones { get; set; } = string.Empty;

    }

    public class HistorialVacunaRes : HistorialVacuna
    {
        // Hereda todas las propiedades
    }

    public class HistorialVacunaReporteRes
    {
        [JsonPropertyName("nombreMascota")]
        public string NombreMascota { get; set; } = string.Empty;

        [JsonPropertyName("nombreVacuna")]
        public string NombreVacuna { get; set; } = string.Empty;

        [JsonPropertyName("fechaAplicacion")]
        public DateTime FechaAplicacion { get; set; }

        [JsonPropertyName("proximaDosis")]
        public DateTime? ProximaDosis { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; } = "Activo";
    }
}