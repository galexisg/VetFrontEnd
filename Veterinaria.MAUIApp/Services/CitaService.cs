using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class CitaService
    {
        private readonly HttpClient _httpClient;

        public CitaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CitaResponse>> GetCitasAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<CitaResponse>>("citas")
                       ?? new List<CitaResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error obteniendo citas: {ex.Message}");
                return new List<CitaResponse>();
            }
        }

        public async Task<CitaResponse?> GetCitaByIdAsync(long id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<CitaResponse>($"citas/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error obteniendo cita {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<CitaResponse?> CreateCitaAsync(CitaRequest cita)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("citas", cita);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<CitaResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error creando cita: {ex.Message}");
                return null;
            }
        }

        public async Task<CitaResponse?> UpdateCitaAsync(long id, CitaRequest cita)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"citas/{id}", cita);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<CitaResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error actualizando cita {id}: {ex.Message}");
                return null;
            }
        }
    }
}
