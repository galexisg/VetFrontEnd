using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
    public class Medicamento
    {
        // Añade al menos los campos que crees que tu API podría devolver
        // como clave primaria (ID) y un nombre.
        public int Id { get; set; }
        public string? Nombre { get; set; }

        // No es necesario añadir todos los campos si no los vas a usar
    }
}
