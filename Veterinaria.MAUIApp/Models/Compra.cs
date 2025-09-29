using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
<<<<<<< Updated upstream
    public class Compra
    {
        // Identificador único de la compra (clave primaria)
        public int CompraId { get; set; }

        // Identificador del proveedor asociado a la compra
        public int ProveedorId { get; set; }

        // Fecha y hora en que se realizó la compra
        public DateTime FechaCompra { get; set; }

        // Identificador del usuario que registró o autorizó la compra
        public int UsuarioId { get; set; }


=======
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Veterinaria.MAUIApp.Models
    {
        public class Compra
        {
            // Identificador único de la compra (clave primaria)
            public int CompraId { get; set; }

            // Identificador del proveedor asociado a la compra
            public int ProveedorId { get; set; }

            // Fecha y hora en que se realizó la compra
            public DateTime FechaCompra { get; set; }

            // Identificador del usuario que registró o autorizó la compra
            public int UsuarioId { get; set; }


        }
>>>>>>> Stashed changes
    }
}

