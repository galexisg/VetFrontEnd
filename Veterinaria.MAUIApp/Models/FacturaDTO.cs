using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
    internal class FacturaDTO
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
