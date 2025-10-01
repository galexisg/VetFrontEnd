using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace Veterinaria.MAUIApp.Models
{
    public class FacturaRequestDTO
    {
        // Requeridos por el backend
        public long ClienteId { get; set; }

        // Si permites crear sin cita en el backend, mantenla nullable
        public long? CitaId { get; set; }

        // "PENDIENTE" | "PARCIAL" | "PAGADA" | "ANULADA" (opcional; backend usa PENDIENTE por defecto)
        public string? Estado { get; set; }

        public string? Observaciones { get; set; }

        // Ítems a facturar (al menos 1). Inicializada para evitar nulls.
        public List<DetalleRequestDTO> Detalles { get; set; } = new();

        // Pago inicial opcional
        public PagoRequestDTO? PagoInicial { get; set; }

        // ================== Clases anidadas ==================

        public class DetalleRequestDTO
        {
            // XOR: usa ServicioId o TratamientoId (no ambos)
            public long? ServicioId { get; set; }
            public long? TratamientoId { get; set; }

            // Texto “congelado” opcional mostrado en la línea
            public string? DescripcionItem { get; set; }

            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }

            // Default 0 para alinear con backend
            public decimal Descuento { get; set; } = 0m;
        }

        public class PagoRequestDTO
        {
            // p.ej. "EFECTIVO", "TARJETA"
            public string Metodo { get; set; } = string.Empty;
            public decimal Monto { get; set; }
            public string? Referencia { get; set; }
            public string? Observaciones { get; set; }
        }
    }
}