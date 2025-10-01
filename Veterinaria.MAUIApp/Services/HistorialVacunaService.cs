using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class HistorialVacunaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:8080/api/v1/historialvacuna"; // ⚠️ Ajusta si cambia tu API

        public HistorialVacunaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // ✅ Obtener todos los historiales
        public async Task<List<HistorialVacunaRes>> GetHistorialesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_baseUrl);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var historiales = JsonSerializer.Deserialize<List<HistorialVacunaRes>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return historiales ?? new List<HistorialVacunaRes>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener historiales: {ex.Message}");
                return new List<HistorialVacunaRes>();
            }
        }

        // ✅ Obtener un historial por ID
        public async Task<HistorialVacunaRes?> GetHistorialByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<HistorialVacunaRes>($"{_baseUrl}/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener historial {id}: {ex.Message}");
                return null;
            }
        }

        // ✅ Obtener vacunas por usuario
        public async Task<List<HistorialVacunaRes>> GetVacunasPorUsuarioAsync(int usuarioId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/usuario/{usuarioId}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var vacunas = JsonSerializer.Deserialize<List<HistorialVacunaRes>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return vacunas ?? new List<HistorialVacunaRes>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener vacunas del usuario {usuarioId}: {ex.Message}");
                return new List<HistorialVacunaRes>();
            }
        }

        // ✅ Crear un nuevo historial
        public async Task<bool> CreateHistorialAsync(HistorialVacunaReq nuevo)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_baseUrl, nuevo);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al crear historial: {ex.Message}");
                return false;
            }
        }

        // ✅ Editar historial existente
        public async Task<bool> UpdateHistorialAsync(int id, HistorialVacunaRes historial)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{id}", historial);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al actualizar historial {id}: {ex.Message}");
                return false;
            }
        }

        // ✅ Eliminar un historial
        public async Task<bool> DeleteHistorialAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al eliminar historial {id}: {ex.Message}");
                return false;
            }
        }

        // ✅ Reporte general
        public async Task<List<HistorialVacunaReporteRes>> GetReporteVacunasAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/reporte");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var reporte = JsonSerializer.Deserialize<List<HistorialVacunaReporteRes>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return reporte ?? new List<HistorialVacunaReporteRes>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al generar reporte: {ex.Message}");
                return new List<HistorialVacunaReporteRes>();
            }
        }
    }
}

