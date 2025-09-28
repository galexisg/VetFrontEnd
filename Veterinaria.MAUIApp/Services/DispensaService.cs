using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class DispensaService
    {
        private readonly HttpClient _http;

        public DispensaService(HttpClient httpClient)
        {
            _http = httpClient;
        }

        // ✅ Obtener todas las dispensas
        public async Task<List<DispensaSalida>> ObtenerTodasAsync()
        {
            try
            {
                var response = await _http.GetAsync("api/dispensas/lista");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<DispensaSalida>>()
                           ?? new List<DispensaSalida>();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new List<DispensaSalida>();
                }
                else
                {
                    throw new HttpRequestException($"Error al obtener dispensas: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al llamar API: {ex.Message}");
                return new List<DispensaSalida>();
            }
        }

        // ✅ Obtener una dispensa por ID
        public async Task<DispensaSalida?> ObtenerPorIdAsync(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<DispensaSalida>($"api/dispensas/{id}");
            }
            catch
            {
                return null;
            }
        }

        // ✅ Crear nueva dispensa (usa DTO de guardar)
        public async Task<DispensaSalida?> CrearAsync(DispensaGuardar dto)
        {
            var response = await _http.PostAsJsonAsync("api/dispensas", dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<DispensaSalida>()
                : null;
        }

        // ✅ Editar dispensa existente (usa DTO de actualizar)
        public async Task<DispensaSalida?> EditarAsync(int id, DispensaActualizar dto)
        {
            var response = await _http.PutAsJsonAsync($"api/dispensas/{id}", dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<DispensaSalida>()
                : null;
        }

        // ✅ Eliminar una dispensa
        public async Task<bool> EliminarAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/dispensas/{id}");
            return response.IsSuccessStatusCode;
        }

        // ✅ Filtrar por prescripción
        public async Task<List<DispensaSalida>> ObtenerPorPrescripcionAsync(int prescripcionDetalleId)
        {
            try
            {
                var response = await _http.GetAsync($"api/dispensas/prescripcion/{prescripcionDetalleId}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<List<DispensaSalida>>() ?? new List<DispensaSalida>();
                return new List<DispensaSalida>();
            }
            catch { return new List<DispensaSalida>(); }
        }

        // ✅ Filtrar por almacén
        public async Task<List<DispensaSalida>> ObtenerPorAlmacenAsync(int almacenId)
        {
            try
            {
                var response = await _http.GetAsync($"api/dispensas/almacen/{almacenId}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<List<DispensaSalida>>() ?? new List<DispensaSalida>();
                return new List<DispensaSalida>();
            }
            catch { return new List<DispensaSalida>(); }
        }

        // ✅ Filtrar por fecha
        public async Task<List<DispensaSalida>> ObtenerPorFechaAsync(DateTime fecha)
        {
            try
            {
                var response = await _http.GetAsync($"api/dispensas/fecha/{fecha:yyyy-MM-dd}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<List<DispensaSalida>>() ?? new List<DispensaSalida>();
                return new List<DispensaSalida>();
            }
            catch { return new List<DispensaSalida>(); }
        }
    }

    // 🔹 Clase de soporte por si tu backend devuelve paginación
    public class ApiPageResponse<T>
    {
        public List<T> Content { get; set; } = new();
        public int TotalPages { get; set; }
        public int TotalElements { get; set; }
        public int Number { get; set; }
        public int Size { get; set; }
    }
}
