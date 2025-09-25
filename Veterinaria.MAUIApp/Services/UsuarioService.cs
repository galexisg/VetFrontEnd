using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _http;

        public UsuarioService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<UsuarioRes>> GetUsuariosAsync()
        {
            return await _http.GetFromJsonAsync<List<UsuarioRes>>("api/usuarios")
                   ?? new List<UsuarioRes>();
        }
    }
}
