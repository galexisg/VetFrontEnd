using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class EspecialidadService
    {
        private readonly HttpClient _http;

        public EspecialidadService(HttpClient httpClient)
        {
            _http = httpClient;
        }

        // ========================
        // 📌 LISTAR
        // ========================
        public async Task<List<Especialidad>> GetActivosAsync()
        {
            return await _http.GetFromJsonAsync<List<Especialidad>>("api/especialidades/activos")
                   ?? new List<Especialidad>();
        }

        public async Task<List<Especialidad>> GetInactivosAsync()
        {
            return await _http.GetFromJsonAsync<List<Especialidad>>("api/especialidades/inactivos")
                   ?? new List<Especialidad>();
        }

        // ========================
        // 📌 OBTENER POR ID
        // ========================
        public async Task<Especialidad?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Especialidad>($"api/especialidades/{id}");
        }

        // ========================
        // 📌 CREAR
        // ========================
        public async Task<Especialidad?> CrearAsync(Especialidad especialidad)
        {
            var response = await _http.PostAsJsonAsync("api/especialidades/Crear", especialidad);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Especialidad>();
            }
            return null;
        }

        // ========================
        // 📌 EDITAR
        // ========================
        public async Task<Especialidad?> EditarAsync(int id, Especialidad especialidad)
        {
            var response = await _http.PutAsJsonAsync($"api/especialidades/{id}/editar", especialidad);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Especialidad>();
            }
            return null;
        }

        // ========================
        // 📌 ACTIVAR
        // ========================
        public async Task<bool> ActivarAsync(int id)
        {
            var response = await _http.PutAsync($"api/especialidades/{id}/activar", null);
            return response.IsSuccessStatusCode;
        }

        // ========================
        // 📌 DESACTIVAR (eliminación lógica)
        // ========================
        public async Task<bool> DesactivarAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/especialidades/{id}/desactivar");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<EspecialidadSalidaRes>> GetActivasAsync()
{
    return await _http.GetFromJsonAsync<List<EspecialidadSalidaRes>>("api/especialidades/activos")
           ?? new List<EspecialidadSalidaRes>();
}

    }
}
