using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class AlmacenService
    {
        private readonly HttpClient _http;

        public AlmacenService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<AlmacenSalida>> ObtenerTodosAsync()
        {
            try
            {
                var response = await _http.GetAsync("api/almacenes/lista");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<List<AlmacenSalida>>() ?? new();
                return new();
            }
            catch
            {
                return new();
            }
        }

        // ✅ Añadir este método
        public async Task<AlmacenSalida?> ObtenerPorIdAsync(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<AlmacenSalida>($"api/almacenes/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<AlmacenSalida?> CrearAsync(AlmacenGuardar dto)
        {
            var response = await _http.PostAsJsonAsync("api/almacenes", dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<AlmacenSalida>()
                : null;
        }

        public async Task<AlmacenSalida?> EditarAsync(int id, AlmacenActualizar dto)
        {
            var response = await _http.PutAsJsonAsync($"api/almacenes/{id}", dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<AlmacenSalida>()
                : null;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/almacenes/{id}");
            return response.IsSuccessStatusCode;
        }

        // ✅ Añadir este método
        public async Task<AlmacenSalida?> CambiarEstadoAsync(int id, bool activo)
        {
            var dto = new AlmacenCambiarEstado { Activo = activo };
            var response = await _http.PutAsJsonAsync($"api/almacenes/{id}/estado", dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<AlmacenSalida>()
                : null;
        }
    }
}
