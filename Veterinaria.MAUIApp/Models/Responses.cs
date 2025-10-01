using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
    public class ErrorResponse
    {
        public string Mensaje { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class SuccessResponse
    {
        public string Mensaje { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class TotalResponse
    {
        public decimal Total { get; set; }
    }

    public class ValidacionResponse
    {
        public bool PuedeRegistrar { get; set; }
        public decimal SaldoDespuesPago { get; set; }
    }
}
