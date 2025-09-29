using System.Text.Json.Serialization;
using System;

namespace Veterinaria.MAUIApp.Models;

public class BloqueHorario
{
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
}