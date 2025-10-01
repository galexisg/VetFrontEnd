using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;

namespace Veterinaria.MAUIApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NickName { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Dui { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; }
        public string Rol { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }

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