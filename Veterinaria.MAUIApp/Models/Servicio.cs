<<<<<<< HEAD
﻿using System.Text.Json.Serialization;
namespace Veterinaria.MAUIApp.Models;
=======
﻿using System;
using System.Text.Json.Serialization;
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981

public class Servicio
{
<<<<<<< HEAD
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = string.Empty; // Valor inicial

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; } = string.Empty; // Valor inicial

    [JsonPropertyName("precioBase")]
    public decimal PrecioBase { get; set; }

    [JsonPropertyName("estado")]
    public EstadoServicio Estado { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }
   
    
   
=======
    public class Servicio
    {
        public long Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal? PrecioBase { get; set; }
        public EstadoServicio Estado { get; set; } = EstadoServicio.ACTIVO;

        [JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
}