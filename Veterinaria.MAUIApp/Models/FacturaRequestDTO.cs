using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
    internal class FacturaRequestDTO
    {
        public long ClienteId { get; set; }
        public List<FacturaDetalleDTO> Detalles { get; set; }
    }
}
