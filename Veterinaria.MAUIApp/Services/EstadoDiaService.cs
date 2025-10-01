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
<<<<<<< HEAD
            var resultado = await _httpClient.GetFromJsonAsync<List<EstadoDia>>("api/v1/estados-dia");
=======
            var resultado = await _httpClient.GetFromJsonAsync<List<EstadoDia>>("v1/estados-dia");
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
            return resultado ?? new List<EstadoDia>();
        }

        public async Task<EstadoDia?> GetEstadoByIdAsync(int id)
        {
<<<<<<< HEAD
            return await _httpClient.GetFromJsonAsync<EstadoDia?>($"api/v1/estados-dia/{id}");
=======
            return await _httpClient.GetFromJsonAsync<EstadoDia?>($"v1/estados-dia/{id}");
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
        }

        public async Task<bool> AddEstadoAsync(EstadoDia estado)
        {
<<<<<<< HEAD
            var response = await _httpClient.PostAsJsonAsync("api/v1/estados-dia", estado);
=======
            var response = await _httpClient.PostAsJsonAsync("v1/estados-dia", estado);
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateEstadoAsync(int id, EstadoDia estado)
        {
<<<<<<< HEAD
            var response = await _httpClient.PutAsJsonAsync($"api/v1/estados-dia/{id}", estado);
=======
            var response = await _httpClient.PutAsJsonAsync($"v1/estados-dia/{id}", estado);
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteEstadoAsync(int id)
        {
<<<<<<< HEAD
            var response = await _httpClient.DeleteAsync($"api/v1/estados-dia/{id}");
=======
            var response = await _httpClient.DeleteAsync($"v1/estados-dia/{id}");
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
            return response.IsSuccessStatusCode;
        }
    }
}