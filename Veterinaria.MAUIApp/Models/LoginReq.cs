using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Models
{
    public class LoginReq
    {
        public string NickName { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
    }

    public class LoginRes
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public UserDto User { get; set; } = new UserDto();

        public class UserDto
        {
            public int Id { get; set; }
            public string NickName { get; set; } = string.Empty;
            public string NombreCompleto { get; set; } = string.Empty;
            public string Rol { get; set; } = string.Empty;
            public string Estado { get; set; } = string.Empty;
        }
    }
}
