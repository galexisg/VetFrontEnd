using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


namespace Veterinaria.MAUIApp.Models
{

    public class DetalleHorarioVeterinario
    {
        [JsonPropertyName("detalleHorarioVeterinarioId")]
        public int DetalleHorarioVeterinarioId { get; set; }

        [JsonPropertyName("veterinarioId")]
        public int VeterinarioId { get; set; }

        [JsonPropertyName("nombreVeterinario")]
        public string NombreVeterinario { get; set; }

        [JsonPropertyName("diaId")]
        public int DiaId { get; set; }

        [JsonPropertyName("dia")]
        public string Dia { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("bloqueHorarioId")]
        public int BloqueHorarioId { get; set; }

        [JsonPropertyName("horaInicio")]
        public TimeSpan HoraInicio { get; set; } // O DateTime

        [JsonPropertyName("horaFin")]
        public TimeSpan HoraFin { get; set; } // O DateTime
    }
}