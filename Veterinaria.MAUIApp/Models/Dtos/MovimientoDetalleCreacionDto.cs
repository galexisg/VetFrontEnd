using System;

namespace Veterinaria.MAUIApp.Models.Dtos
{
    // DTO usado para crear un nuevo registro de detalle de movimiento (POST).
    public class MovimientoDetalleCreacionDto
    {
        public double Cantidad { get; set; }
        public double CostoUnitario { get; set; }

        // La fecha puede ser enviada por el cliente o generada en el servidor (depende de tu API).
        public DateTime Fecha { get; set; }

        // IDs de las relaciones (necesarias para enlazar el detalle):
        public int MovimientoInventarioId { get; set; } // Mapea a 'movimiento_id'
        public int MedicamentoId { get; set; } // Mapea a 'medicamento_id'
        public int LoteMedicamentoId { get; set; } // Mapea a 'lote_id'
        public int AlmacenId { get; set; } // Mapea a 'almacen_id'
        public int UsuarioId { get; set; } // Mapea a 'usuario_id'
    }
}