using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
    public class Especialidad
    {
        // Igual que en el backend
        public int EspecialidadId { get; set; }

        // Nombre de la especialidad
        public string Nombre { get; set; } = string.Empty;

        // Eliminación lógica
        public bool Activo { get; set; }

        // ⚠️ En el backend existe una relación con Veterinario,
        // pero aquí normalmente no la incluimos para evitar ciclos JSON
        // Si solo quieres mostrar los veterinarios, podrías agregar:
        // public List<Veterinario>? Veterinarios { get; set; }
    }


    public class EspecialidadSalidaRes
    {
        public int EspecialidadId { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}


