using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models.Dtos
{
    public class MovimientoInventarioActualizacionDto
    {
        // Obligatorio para la actualización
        [JsonPropertyName("id")]
        public int Id { get; set; }

        // El campo Tipo corresponde a ENTRADA o SALIDA.
        [JsonPropertyName("tipo")]
        public string Tipo { get; set; }

        [JsonPropertyName("observacion")]
        public string Observacion { get; set; }

        // NOTA: La Fecha se mantiene aquí por si se permite editar, aunque usualmente se maneja en el backend.
        // Si el backend no acepta la fecha en la edición, esta propiedad puede eliminarse.
        [JsonPropertyName("fecha")]
        public DateTime Fecha { get; set; }
    }
}
