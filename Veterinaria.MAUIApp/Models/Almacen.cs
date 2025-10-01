using System.ComponentModel.DataAnnotations;

namespace Veterinaria.MAUIApp.Models
{
    public class AlmacenGuardar
    {
        [Required(ErrorMessage = "El nombre del almacén es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ubicación es obligatoria.")]
        public string Ubicacion { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;
    }

    public class AlmacenActualizar
    {
        public string Nombre { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
    }

    public class AlmacenCambiarEstado
    {
        public bool Activo { get; set; }
    }

    public class AlmacenSalida
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
