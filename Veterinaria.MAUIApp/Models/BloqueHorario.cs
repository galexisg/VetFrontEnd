using System.Text.Json.Serialization;
using System;

namespace Veterinaria.MAUIApp.Models;

public class BloqueHorario
{
<<<<<<< HEAD
    [JsonPropertyName("bloqueHorarioId")]
    public int BloqueHorarioId { get; set; }

    [JsonPropertyName("inicio")]
    public TimeSpan Inicio { get; set; }

    [JsonPropertyName("fin")]
    public TimeSpan Fin { get; set; }

    [JsonPropertyName("activo")]
    public bool Activo { get; set; }
=======
    public class BloqueHorarioGuardarReq
    {
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fin { get; set; }
    }

    public class BloqueHorarioModificarReq
    {
        public int Id { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fin { get; set; }
        public bool Activo { get; set; }
    }

    public class BloqueHorarioSalidaRes
    {
        public int Id { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fin { get; set; }
        public bool Activo { get; set; }
    }
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
}