using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
    public class Vacuna
    {
        [JsonPropertyName("vacunaId")]
        public int Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [JsonPropertyName("estado")]
        public bool Estado { get; set; }
    }

    // Lo que envías al backend
    public class VacunaReq
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(80, ErrorMessage = "Máximo 80 caracteres")]
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;
    }
}

