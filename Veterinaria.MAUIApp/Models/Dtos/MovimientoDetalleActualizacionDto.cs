using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.MAUIApp.Models.Dtos;

namespace Veterinaria.MAUIApp.Models.Dtos
{
    // DTO usado para actualizar un registro de detalle de movimiento (PUT).
    // Hereda todas las propiedades del DTO de Creación (Cantidad, CostoUnitario, Fecha, y todas las IDs).
    public class MovimientoDetalleActualizacionDto 
    {
        [Required]
        public int Id { get; set; } // Clave principal para la edición

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        public double Cantidad { get; set; }

        [Required(ErrorMessage = "El costo unitario es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El costo unitario debe ser mayor que cero.")]
        public double CostoUnitario { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        // ----------------- IDs de Relación -----------------

        [Required(ErrorMessage = "El ID del medicamento es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del medicamento debe ser válido.")]
        public int MedicamentoId { get; set; }

        [Required(ErrorMessage = "El ID del lote es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del lote debe ser válido.")]
        public int LoteMedicamentoId { get; set; }

        [Required(ErrorMessage = "El ID del almacén es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del almacén debe ser válido.")]
        public int AlmacenId { get; set; }

        [Required(ErrorMessage = "El ID del movimiento de inventario es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del movimiento de inventario debe ser válido.")]
        public int MovimientoInventarioId { get; set; }

        [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del usuario debe ser válido.")]
        public int UsuarioId { get; set; }
    }
}
