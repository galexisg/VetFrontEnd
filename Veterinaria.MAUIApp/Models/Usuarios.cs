using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
<<<<<<< HEAD

namespace Veterinaria.MAUIApp.Models
{
    public class UsuarioRes
=======
using System.ComponentModel.DataAnnotations;

namespace Veterinaria.MAUIApp.Models
{
    public class Usuario
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
    {
        public int Id { get; set; }
        public string NickName { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Dui { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
<<<<<<< HEAD
        public DateTime FechaNacimiento { get; set; }
=======
        public DateTime? FechaNacimiento { get; set; }
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
        public string Rol { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }

<<<<<<< HEAD
}
=======
    // DTO para crear/editar usuario
    public class UsuarioReq
    {
        public string NickName { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Dui { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; }
        public byte RolId { get; set; }
        public byte EstadoId { get; set; }
    }
 
}
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
