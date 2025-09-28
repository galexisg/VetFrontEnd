namespace Veterinaria.MAUIApp.Models
{
    // ✅ Equivalente a Dispensa_Guardar del backend
    public class DispensaGuardar
    {
        public int PrescripcionDetalleId { get; set; }
        public int AlmacenId { get; set; }      // ID para guardar
        public int LoteId { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }      // ID para guardar
    }

    // ✅ Equivalente a Dispensa_Actualizar del backend
    public class DispensaActualizar
    {
        public int PrescripcionDetalleId { get; set; }
        public int AlmacenId { get; set; }       // ID del almacén a actualizar
        public int LoteId { get; set; }          // ID del lote
        public decimal Cantidad { get; set; }    // Cantidad a actualizar
        public DateTime Fecha { get; set; }      // Fecha de actualización
        public int UsuarioId { get; set; }

        // ⚠️ Opcionales (solo para mostrar, no se envían en update)
        public string? AlmacenNombre { get; set; } = string.Empty;
        public string? UsuarioNombre { get; set; } = string.Empty;
    }

    // ✅ Equivalente a Dispensa_Salida del backend
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
