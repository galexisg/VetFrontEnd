using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
    public class UsuarioMiniDTO
    {
        [JsonPropertyName("id")] public int UsuarioId { get; set; }          
        [JsonPropertyName("nombreCompleto")] public string? NombreCompleto { get; set; }
    }
}
