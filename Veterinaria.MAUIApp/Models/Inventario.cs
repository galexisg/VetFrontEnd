using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
    public class Inventario
    {
        public int Id { get; set; }

        public double StockActual { get; set; }

        public double StockMinimo { get; set; }

        public double StockMaximo { get; set; }

        // Propiedades de navegación. El '?' indica que pueden ser nulas.
        // Las clases Medicamento y Almacen deben existir en este namespace.
        public Medicamento? Medicamento { get; set; }
        public Almacen? Almacen { get; set; }
    }
}
