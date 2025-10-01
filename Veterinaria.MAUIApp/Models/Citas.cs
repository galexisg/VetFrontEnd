namespace Veterinaria.MAUIApp.Models
{
    public class Citas
    {
        public long CitaId { get; set; }
        public int MascotaId { get; set; }
        public int UsuarioId { get; set; }
        public int MotivoId { get; set; }
        public int EstadoId { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
