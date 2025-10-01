using System;
using System.ComponentModel.DataAnnotations;

namespace Veterinaria.MAUIApp.Models
{
    public class VeterinarioSalidaRes
    {
        public int Id { get; set; }
        public string NumeroLicencia { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activo"; // <-- Corrige mayúsculas
        public string Especialidad { get; set; } = string.Empty;
        public string Servicio { get; set; } = string.Empty;
        public Usuario Usuario { get; set; } = new();
    }


    public class VeterinarioGuardarReq
    {
        [Required(ErrorMessage = "La licencia es obligatoria")]
        public string NumeroLicencia { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un usuario")]
        public int? UsuarioId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una especialidad")]
        public int? EspecialidadId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un servicio")]
        public long? ServicioId { get; set; }
    }

    public class VeterinarioModificarReq
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La licencia es obligatoria")]
        public string NumeroLicencia { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un usuario")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una especialidad")]
        public int EspecialidadId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un servicio")]
        public long ServicioId { get; set; }

        public string Estado { get; set; } = "ACTIVO";
    }
    public class VeterinarioEstadoReq
    {
        public int Id { get; set; }
        public string Estado { get; set; } = "Activo"; // o "Inactivo"
    }

    public class UsuarioSalidaRes
    {
        public int Id { get; set; }
        public string NickName { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Dui { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string FechaNacimiento { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
