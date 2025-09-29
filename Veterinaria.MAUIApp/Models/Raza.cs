namespace Veterinaria.MAUIApp.Models
{
    public class RazaGuardarReq
    {
        public string Nombre { get; set; } = string.Empty;
        public byte EspecieId { get; set; }
        public string EspecieNombre { get; set; } = string.Empty;
    }

    public class RazaModificarReq
    {
        public byte Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public byte EspecieId { get; set; }
        public string EspecieNombre { get; set; } = string.Empty;
    }

    public class RazaSalidaRes
    {
        public byte Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public byte EspecieId { get; set; }
        public string EspecieNombre { get; set; } = string.Empty;
    }
}
