using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class VeterinarioService
    {
        private readonly HttpClient _http;

        public VeterinarioService(HttpClient http)
        {
            _http = http;
        }

        // 📌 Listar todos
        public async Task<List<VeterinarioSalidaRes>> ListarAsync()
        {
            return await _http.GetFromJsonAsync<List<VeterinarioSalidaRes>>("veterinarios")
                   ?? new List<VeterinarioSalidaRes>();
        }

        // 📌 Listar activos
        public async Task<List<VeterinarioSalidaRes>> ListarActivos()
        {
            return await _http.GetFromJsonAsync<List<VeterinarioSalidaRes>>("veterinarios/activos")
                   ?? new List<VeterinarioSalidaRes>();
        }

        // 📌 Listar inactivos
        public async Task<List<VeterinarioSalidaRes>> ListarInactivos()
        {
            return await _http.GetFromJsonAsync<List<VeterinarioSalidaRes>>("veterinarios/inactivos")
                   ?? new List<VeterinarioSalidaRes>();
        }

        // 📌 Obtener por ID
        public async Task<VeterinarioSalidaRes?> ObtenerAsync(int id)
        {
            return await _http.GetFromJsonAsync<VeterinarioSalidaRes>($"veterinarios/{id}");
        }

        // 📌 Crear
        public async Task<bool> CrearAsync(VeterinarioGuardarReq modelo)
        {
            var response = await _http.PostAsJsonAsync("veterinarios", modelo);
            return response.IsSuccessStatusCode;
        }

        // 📌 Editar
        public async Task<bool> EditarAsync(int id, VeterinarioModificarReq modelo)
        {
            var response = await _http.PutAsJsonAsync($"veterinarios/{id}", modelo);
            return response.IsSuccessStatusCode;
        }

        // 📌 Activar
        public async Task<bool> ActivarAsync(int id)
        {
            var response = await _http.PutAsync($"veterinarios/{id}/activar", null);
            return response.IsSuccessStatusCode;
        }

        // 📌 Inactivar
        public async Task<bool> InactivarAsync(int id)
        {
            var response = await _http.PutAsync($"veterinarios/{id}/inactivar", null);
            return response.IsSuccessStatusCode;
        }
    }
}