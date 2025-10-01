using System;

namespace VetApp.Models
{
    public class Compra
    {
        public long Id { get; set; } // Normalmente lo devuelve tu API
        public int ProveedorId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public double Total { get; set; }
    }

    public class CompraCrear
    {
        public int ProveedorId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public double Total { get; set; }
    }

    public class CompraActualizar
    {
        public int ProveedorId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public double Total { get; set; }
    }

    public class CompraCancelar
    {
        public string MotivoCancelacion { get; set; }
    }

    public class CompraDetalle
    {
        public long Id { get; set; }
        public long CompraId { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }

    public class CrearDetalle
    {
        public long CompraId { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }

    public class ActualizarDetalle
    {
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }

    public class CancelarDetalle
    {
        public string Motivo { get; set; }
    }
}
