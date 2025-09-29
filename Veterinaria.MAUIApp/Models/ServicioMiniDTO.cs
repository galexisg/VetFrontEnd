using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
    public class ServicioMiniDTO
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public decimal? PrecioBase { get; set; }
    }
}
