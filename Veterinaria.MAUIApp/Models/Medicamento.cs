using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApplication.Models
{
    public class Medicamento
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Formafarmacautica { get; set; }
        public string Concentracion { get; set; }
        public string Unidad { get; set; }
        public string Via { get; set; }
        public bool RequiereReceta { get; set; }
        public bool Activo { get; set; }
        public string Temperaturaalm { get; set; }
        public int Vidautilmeses { get; set; }
    }
}

