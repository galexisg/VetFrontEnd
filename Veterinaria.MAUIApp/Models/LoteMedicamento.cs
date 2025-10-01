using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models.Dtos
{
    public class LoteMedicamentoSalida
    {
        public int Id { get; set; }
        public string CodigoLote { get; set; } = string.Empty;
        public DateTime FechaVencimiento { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public int MedicamentoId { get; set; }
        public string MedicamentoNombre { get; set; } = string.Empty;
        public int ProveedorId { get; set; }
        public string ProveedorNombre { get; set; } = string.Empty;
    }

public class LoteMedicamentoGuardar
    {
        [Required]
        public string CodigoLote { get; set; } = string.Empty;

        [Required]
        public DateTime FechaVencimiento { get; set; }

        public string Observaciones { get; set; } = string.Empty;

        [Required]
        public int MedicamentoId { get; set; }

        [Required]
        public int ProveedorId { get; set; }
    }


    public class LoteMedicamentoActualizar
    {
        public int Id { get; set; }
        public string CodigoLote { get; set; } = string.Empty;
        public DateTime FechaVencimiento { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public int MedicamentoId { get; set; }
        public int ProveedorId { get; set; }
    }
}

