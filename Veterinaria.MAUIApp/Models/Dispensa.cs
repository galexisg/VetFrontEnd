using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
        public class Dispensa_Guardar
        {
            public int PrescripcionDetalleId { get; set; }
            public int AlmacenId { get; set; }
            public int LoteId { get; set; }
            public decimal Cantidad { get; set; }
            public DateTime Fecha { get; set; }
            public int UsuarioId { get; set; }
        }

    public class Dispensa_Salida
    {
        public int Id { get; set; }
        public int PrescripcionDetalleId { get; set; }
        public int AlmacenId { get; set; }
        public int LoteId { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
    }
        public class Dispensa_Actualizar
        {
            public int AlmacenId { get; set; }
            public int LoteId { get; set; }
            public decimal Cantidad { get; set; }
            public DateTime Fecha { get; set; }
            public int PrescripcionDetalleId { get; set; }
            public int UsuarioId { get; set; }
        }

}
