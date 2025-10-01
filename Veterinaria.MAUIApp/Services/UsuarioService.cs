using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veterinaria.MAUIApp.Models;

using System.Net.Http.Headers;
using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _http;

        public UsuarioService(HttpClient http)
        {
            _http = http;
<<<<<<< HEAD
        }

        public async Task<List<UsuarioRes>> GetUsuariosAsync()
        {
            return await _http.GetFromJsonAsync<List<UsuarioRes>>("api/usuarios")
                   ?? new List<UsuarioRes>();
=======
            // Si ya tienes token JWT guardado
            // _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Usuario>>("usuarios/listarclientes") ?? new List<Usuario>();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Usuario>($"usuarios/{id}");
        }

        public async Task<Usuario?> CrearAsync(UsuarioReq usuario)
        {
            var response = await _http.PostAsJsonAsync("usuarios", usuario);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Usuario>();
            }
            return null;
        }

        public async Task<Usuario?> EditarAsync(int id, UsuarioReq usuario)
        {
            var response = await _http.PutAsJsonAsync($"usuarios/{id}", usuario);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Usuario>();
            }
            return null;
        }

        public async Task ActivarAsync(int id)
        {
            await _http.PatchAsync($"usuarios/activar/{id}", null);
        }

        public async Task DesactivarAsync(int id)
        {
            await _http.PatchAsync($"usuarios/desactivar/{id}", null);
        }

        // Opcional: listar activos e inactivos
        public async Task<List<Usuario>> GetActivosAsync()
        {
            return await _http.GetFromJsonAsync<List<Usuario>>("usuarios/activos") ?? new List<Usuario>();
        }

        public async Task<List<Usuario>> GetInactivosAsync()
        {
            return await _http.GetFromJsonAsync<List<Usuario>>("usuarios/inactivos") ?? new List<Usuario>();
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
        }
    }
}