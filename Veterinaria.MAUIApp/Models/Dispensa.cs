using System.ComponentModel.DataAnnotations;

namespace Veterinaria.MAUIApp.Models
{
    public class DispensaGuardar
    {
      
        [Required(ErrorMessage = "La prescripción es obligatoria")]
        public int PrescripcionDetalleId { get; set; }

        [Required(ErrorMessage = "El almacén es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un almacén válido")]
        public int AlmacenId { get; set; }

        [Required(ErrorMessage = "El lote es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un lote válido")]
        public int LoteId { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor a cero")]
        public decimal Cantidad { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un usuario válido")]
        public int UsuarioId { get; set; }
    }


public class DispensaActualizar
    {
        public int PrescripcionDetalleId { get; set; }
        public int AlmacenId { get; set; }       
        public int LoteId { get; set; }         
        public decimal Cantidad { get; set; }    
        public DateTime Fecha { get; set; }     
        public int UsuarioId { get; set; }

      
        public string? AlmacenNombre { get; set; } = string.Empty;
        public string? UsuarioNombre { get; set; } = string.Empty;
    }

    public class DispensaSalida
    {
        public int Id { get; set; }
        public int PrescripcionDetalleId { get; set; }
        public int LoteId { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        // Nuevos campos que el backend devuelve
        public string UsuarioNombre { get; set; } = string.Empty;
        public string AlmacenNombre { get; set; } = string.Empty;
    }

    public class UsuarioDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
    }

    public class AlmacenDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

}
