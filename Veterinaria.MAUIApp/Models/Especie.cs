namespace Veterinaria.MAUIApp.Models
{
    public class EspecieGuardarReq
    {
        public string Nombre { get; set; } = string.Empty;
    }

    public class EspecieActualizarReq
    {
        public byte EspecieId { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

    public class EspecieRes
    {
        public byte EspecieId { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
