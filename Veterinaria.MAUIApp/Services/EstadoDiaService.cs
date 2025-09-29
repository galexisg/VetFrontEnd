using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class EstadoDiaService
    {
        private readonly HttpClient _httpClient;

        public EstadoDiaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EstadoDia>> GetEstadosAsync()
        {
            // CORRECCIÓN: La ruta ahora coincide con tu controller de Java
            var resultado = await _httpClient.GetFromJsonAsync<List<EstadoDia>>("api/v1/estados-dia");
            return resultado ?? new List<EstadoDia>();
        }

        public async Task<EstadoDia?> GetEstadoByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<EstadoDia?>($"api/v1/estados-dia/{id}");
        }

        public async Task<bool> AddEstadoAsync(EstadoDia estado)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/estados-dia", estado);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateEstadoAsync(int id, EstadoDia estado)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/estados-dia/{id}", estado);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteEstadoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/estados-dia/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}