using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{


    public class VeterinarioSalidaRes
    {
        public int Id { get; set; }
        public string NumeroLicencia { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activo";
        public string Especialidad { get; set; } = string.Empty;
        public string Servicio { get; set; } = string.Empty;
        public UsuarioRes Usuario { get; set; } = new();
    }
    public class VeterinarioModificarReq
    {
        public int Id { get; set; }
        public string NumeroLicencia { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
        public int EspecialidadId { get; set; }
        public long ServicioId { get; set; }
        public string Estado { get; set; } = "Activo";
    }
    public class VeterinarioGuardarReq
    {
        public string NumeroLicencia { get; set; } = string.Empty;

        public int? UsuarioId { get; set; }

        public int? EspecialidadId { get; set; }

       
        public int? ServicioId { get; set; }

   

        public class EspecialidadRes
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
        }

        public class ServicioRes
        {
            public long Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
        }

    }
}

