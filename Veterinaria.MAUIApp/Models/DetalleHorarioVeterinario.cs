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
<<<<<<< HEAD
        public int VeterinarioId { get; set; }
=======
        public int? VeterinarioId { get; set; }
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981

        [JsonPropertyName("nombreVeterinario")]
        public string NombreVeterinario { get; set; }

        [JsonPropertyName("diaId")]
<<<<<<< HEAD
        public int DiaId { get; set; }
=======
        public int? DiaId { get; set; }
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981

        [JsonPropertyName("dia")]
        public string Dia { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("bloqueHorarioId")]
<<<<<<< HEAD
        public int BloqueHorarioId { get; set; }
=======
        public int? BloqueHorarioId { get; set; }
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981

        [JsonPropertyName("horaInicio")]
        public TimeSpan HoraInicio { get; set; } // O DateTime

        [JsonPropertyName("horaFin")]
        public TimeSpan HoraFin { get; set; } // O DateTime
    }
}