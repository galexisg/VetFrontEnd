
using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class DiaService
    {
        private readonly HttpClient _httpClient;

        public DiaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Dia>> GetDiasAsync()
        {
            // CORRECCIÓN: La ruta ahora coincide con tu controller de Java
            var resultado = await _httpClient.GetFromJsonAsync<List<Dia>>("api/v1/dias");
            return resultado ?? new List<Dia>();
        }

        public async Task<Dia?> GetDiaByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Dia?>($"api/v1/dias/{id}");
        }

        public async Task<bool> AddDiaAsync(Dia dia)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/dias", dia);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateDiaAsync(int id, Dia dia)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/dias/{id}", dia);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteDiaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/dias/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}