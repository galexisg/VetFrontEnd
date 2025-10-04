using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models.Dtos
{
    public class InventarioActualizacionDto
    {
        // El Id es crucial para que el backend sepa qué registro actualizar.
        [Required] // Aunque viene de la ruta, es buena práctica
        public int Id { get; set; }

        // Propiedades de stock
        [Required(ErrorMessage = "El stock actual es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El stock actual no puede ser negativo.")]
        public double StockActual { get; set; }

        [Required(ErrorMessage = "El stock mínimo es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El stock mínimo no puede ser negativo.")]
        public double StockMinimo { get; set; }

        [Required(ErrorMessage = "El stock máximo es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El stock máximo no puede ser negativo.")]
        public double StockMaximo { get; set; }

        // Propiedades de relación
        [Required(ErrorMessage = "Se requiere el ID del medicamento.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del medicamento debe ser válido.")]
        public int MedicamentoId { get; set; }

        [Required(ErrorMessage = "Se requiere el ID del almacén.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del almacén debe ser válido.")]
        public int AlmacenId { get; set; }
    }
}