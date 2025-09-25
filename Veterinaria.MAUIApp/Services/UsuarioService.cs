using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // Si ya tienes token JWT guardado
            // _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Usuario>>("api/usuarios/listarclientes") ?? new List<Usuario>();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Usuario>($"api/usuarios/{id}");
        }

        public async Task<Usuario?> CrearAsync(UsuarioReq usuario)
        {
            var response = await _http.PostAsJsonAsync("api/usuarios", usuario);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Usuario>();
            }
            return null;
        }

        public async Task<Usuario?> EditarAsync(int id, UsuarioReq usuario)
        {
            var response = await _http.PutAsJsonAsync($"api/usuarios/{id}", usuario);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Usuario>();
            }
            return null;
        }

        public async Task ActivarAsync(int id)
        {
            await _http.PatchAsync($"api/usuarios/activar/{id}", null);
        }

        public async Task DesactivarAsync(int id)
        {
            await _http.PatchAsync($"api/usuarios/desactivar/{id}", null);
        }

        // Opcional: listar activos e inactivos
        public async Task<List<Usuario>> GetActivosAsync()
        {
            return await _http.GetFromJsonAsync<List<Usuario>>("api/usuarios/activos") ?? new List<Usuario>();
        }

        public async Task<List<Usuario>> GetInactivosAsync()
        {
            return await _http.GetFromJsonAsync<List<Usuario>>("api/usuarios/inactivos") ?? new List<Usuario>();
        }
    }
}

