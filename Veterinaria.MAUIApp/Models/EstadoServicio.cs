<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models;

public enum EstadoServicio
{
    ACTIVO,
    INACTIVO
=======
﻿using System.Text.Json.Serialization;

namespace Veterinaria.MAUIApp.Models
{
    // Hace que System.Text.Json (de)serialice "ACTIVO"/"INACTIVO" como texto
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EstadoServicio
    {
        ACTIVO,
        INACTIVO
    }
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
}