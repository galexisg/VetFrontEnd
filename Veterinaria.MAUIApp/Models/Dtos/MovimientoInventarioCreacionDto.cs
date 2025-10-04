using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models.Dtos
{
    public class MovimientoInventarioCreacionDto
    {
        // El campo Tipo corresponde a ENTRADA o SALIDA.
        // Se asume que el backend espera un String con uno de los valores del Enum (por ejemplo, "ENTRADA").
        [JsonPropertyName("tipo")]
        public string Tipo { get; set; }

        [JsonPropertyName("observacion")]
        public string Observacion { get; set; }

        // La Fecha en que ocurre el movimiento. Es crucial para el registro.
        [JsonPropertyName("fecha")]
        [Required(ErrorMessage = "La fecha del movimiento es obligatoria.")]
        public DateTime Fecha { get; set; } = DateTime.Now; // Inicialización por defecto a hoy
    }
}
