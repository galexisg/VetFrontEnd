using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
    public class TratamientoAplicado
    {
        public long Id { get; set; }
        public long CitaId { get; set; }
        public long TratamientoId { get; set; }
        public long VeterinarioId { get; set; }
        public string? Estado { get; set; }          // "Pendiente", "Planificado", "EnCurso", "Completado", "Cancelado"
        public string? Observaciones { get; set; }
    }
}
