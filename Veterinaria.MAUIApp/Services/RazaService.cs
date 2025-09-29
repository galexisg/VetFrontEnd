using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class RazaService
    {
        private readonly HttpClient _http;
        private const string BaseUrl = "api/raza";

        public RazaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<RazaSalidaRes>> ObtenerTodosAsync()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<List<RazaSalidaRes>>($"{BaseUrl}/lista");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ObtenerTodosAsync] Error: {ex.Message}");
                return new(); // Evita que Blazor falle
            }
        }

        public async Task<RazaSalidaRes?> ObtenerPorIdAsync(byte id)
        {
            try
            {
                return await _http.GetFromJsonAsync<RazaSalidaRes>($"{BaseUrl}/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ObtenerPorIdAsync] Error: {ex.Message}");
                return null;
            }
        }

        public async Task<RazaSalidaRes?> CrearAsync(RazaGuardarReq nuevaRaza)
        {
            try
            {
                var response = await _http.PostAsJsonAsync(BaseUrl, nuevaRaza);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<RazaSalidaRes>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CrearAsync] Error: {ex.Message}");
                return null;
            }
        }

        public async Task<RazaSalidaRes?> EditarAsync(byte id, RazaModificarReq raza)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"{BaseUrl}/{id}", raza);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<RazaSalidaRes>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EditarAsync] Error: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> EliminarAsync(byte id)
        {
            try
            {
                var response = await _http.DeleteAsync($"{BaseUrl}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EliminarAsync] Error: {ex.Message}");
                return false;
            }
        }
    }
}
