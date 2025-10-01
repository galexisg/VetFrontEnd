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
<<<<<<< HEAD
            return await _http.GetFromJsonAsync<List<Especialidad>>("api/especialidades/activos")
=======
            return await _http.GetFromJsonAsync<List<Especialidad>>("especialidades/activos")
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
                   ?? new List<Especialidad>();
        }

        public async Task<List<Especialidad>> GetInactivosAsync()
        {
<<<<<<< HEAD
            return await _http.GetFromJsonAsync<List<Especialidad>>("api/especialidades/inactivos")
=======
            return await _http.GetFromJsonAsync<List<Especialidad>>("especialidades/inactivos")
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
                   ?? new List<Especialidad>();
        }

        // ========================
        // 📌 OBTENER POR ID
        // ========================
        public async Task<Especialidad?> GetByIdAsync(int id)
        {
<<<<<<< HEAD
            return await _http.GetFromJsonAsync<Especialidad>($"api/especialidades/{id}");
=======
            return await _http.GetFromJsonAsync<Especialidad>($"especialidades/{id}");
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
        }

        // ========================
        // 📌 CREAR
        // ========================
        public async Task<Especialidad?> CrearAsync(Especialidad especialidad)
        {
<<<<<<< HEAD
            var response = await _http.PostAsJsonAsync("api/especialidades/Crear", especialidad);
=======
            var response = await _http.PostAsJsonAsync("especialidades/Crear", especialidad);
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981

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
<<<<<<< HEAD
            var response = await _http.PutAsJsonAsync($"api/especialidades/{id}/editar", especialidad);
=======
            var response = await _http.PutAsJsonAsync($"especialidades/{id}/editar", especialidad);
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981

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
<<<<<<< HEAD
            var response = await _http.PutAsync($"api/especialidades/{id}/activar", null);
=======
            var response = await _http.PutAsync($"especialidades/{id}/activar", null);
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
            return response.IsSuccessStatusCode;
        }

        // ========================
        // 📌 DESACTIVAR (eliminación lógica)
        // ========================
        public async Task<bool> DesactivarAsync(int id)
        {
<<<<<<< HEAD
            var response = await _http.DeleteAsync($"api/especialidades/{id}/desactivar");
=======
            var response = await _http.DeleteAsync($"especialidades/{id}/desactivar");
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
            return response.IsSuccessStatusCode;
        }

        public async Task<List<EspecialidadSalidaRes>> GetActivasAsync()
{
<<<<<<< HEAD
    return await _http.GetFromJsonAsync<List<EspecialidadSalidaRes>>("api/especialidades/activos")
=======
    return await _http.GetFromJsonAsync<List<EspecialidadSalidaRes>>("especialidades/activos")
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
           ?? new List<EspecialidadSalidaRes>();
}

    }
}
