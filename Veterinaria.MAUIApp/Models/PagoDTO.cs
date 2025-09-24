using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
    internal class PagoDTO
    {
        public long Id { get; set; }
        public long FacturaId { get; set; }
        public string Metodo { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
