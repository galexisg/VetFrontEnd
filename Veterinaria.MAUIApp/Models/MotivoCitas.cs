using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
    public class MotivoCita
    {
        public int Id { get; set; }

        [RegularExpression(@"^[\p{L} ]+$", ErrorMessage = "El nombre solo puede contener letras")]
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public bool Activo { get; set; } = true;
    }

    }


