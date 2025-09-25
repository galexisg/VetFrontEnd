using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Veterinaria.MAUIApp.Models
{
    public class Rol
    {
        public byte Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(45, ErrorMessage = "El nombre no puede exceder 45 caracteres")]
        public string Nombre { get; set; } = string.Empty;
    }
}

