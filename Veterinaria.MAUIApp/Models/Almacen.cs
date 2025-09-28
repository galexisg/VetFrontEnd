namespace Veterinaria.MAUIApp.Models
{
    public class AlmacenGuardar
    {
        public string Nombre { get; set; } = string.Empty;
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
