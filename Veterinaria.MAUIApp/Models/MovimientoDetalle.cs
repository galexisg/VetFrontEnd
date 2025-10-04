using System;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Models
{
    // Clase principal del detalle del movimiento de inventario
    public class MovimientoDetalle
    {
        public int Id { get; set; }

        public double Cantidad { get; set; }

        public double CostoUnitario { get; set; }

        // Mapea a java.time.LocalDateTime. 
        // DateTime es el tipo estándar en C# para fecha y hora.
        public DateTime Fecha { get; set; }

        // Relaciones ManyToOne:
        public MovimientoInventario? MovimientoInventario { get; set; }
        public Medicamento? Medicamento { get; set; }
        public LoteMedicamento? LoteMedicamento { get; set; }
        public Almacen? Almacen { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
