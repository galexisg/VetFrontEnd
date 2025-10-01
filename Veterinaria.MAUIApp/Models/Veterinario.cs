using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{


=======
using System.ComponentModel.DataAnnotations;

namespace Veterinaria.MAUIApp.Models
{
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
    public class VeterinarioSalidaRes
    {
        public int Id { get; set; }
        public string NumeroLicencia { get; set; } = string.Empty;
<<<<<<< HEAD
        public string Estado { get; set; } = "Activo";
        public string Especialidad { get; set; } = string.Empty;
        public string Servicio { get; set; } = string.Empty;
        public UsuarioRes Usuario { get; set; } = new();
    }
    public class VeterinarioModificarReq
    {
        public int Id { get; set; }
        public string NumeroLicencia { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
        public int EspecialidadId { get; set; }
        public long ServicioId { get; set; }
        public string Estado { get; set; } = "Activo";
    }
    public class VeterinarioGuardarReq
    {
        public string NumeroLicencia { get; set; } = string.Empty;

        public int? UsuarioId { get; set; }

        public int? EspecialidadId { get; set; }

       
        public int? ServicioId { get; set; }

   

        public class EspecialidadRes
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
        }

        public class ServicioRes
        {
            public long Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
        }

=======
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
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
    }
}

