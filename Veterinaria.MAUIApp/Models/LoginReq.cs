using System;
using System.Text.Json.Serialization;

namespace Veterinaria.MAUIApp.Models
{
    public class LoginReq
    {
        [JsonPropertyName("nickName")]
        public string NickName { get; set; } = string.Empty;

        [JsonPropertyName("clave")]
        public string Clave { get; set; } = string.Empty;
    }

    public class LoginRes
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;

        [JsonPropertyName("expiresAt")]
        public DateTime ExpiresAt { get; set; }

        [JsonPropertyName("user")]
        public UserDto User { get; set; } = new UserDto();

        public class UserDto
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("nickName")]
            public string NickName { get; set; } = string.Empty;

            [JsonPropertyName("nombreCompleto")]
            public string NombreCompleto { get; set; } = string.Empty;

            [JsonPropertyName("rol")]
            public string Rol { get; set; } = string.Empty;

            [JsonPropertyName("estado")]
            public string Estado { get; set; } = string.Empty;
        }
    }
}
