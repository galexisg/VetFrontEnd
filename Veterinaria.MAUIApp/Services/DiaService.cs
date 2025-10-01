
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
<<<<<<< HEAD
            var resultado = await _httpClient.GetFromJsonAsync<List<Dia>>("api/v1/dias");
=======
            var resultado = await _httpClient.GetFromJsonAsync<List<Dia>>("v1/dias");
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
            return resultado ?? new List<Dia>();
        }

        public async Task<Dia?> GetDiaByIdAsync(int id)
        {
<<<<<<< HEAD
            return await _httpClient.GetFromJsonAsync<Dia?>($"api/v1/dias/{id}");
=======
            return await _httpClient.GetFromJsonAsync<Dia?>($"v1/dias/{id}");
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
        }

        public async Task<bool> AddDiaAsync(Dia dia)
        {
<<<<<<< HEAD
            var response = await _httpClient.PostAsJsonAsync("api/v1/dias", dia);
=======
            var response = await _httpClient.PostAsJsonAsync("v1/dias", dia);
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateDiaAsync(int id, Dia dia)
        {
<<<<<<< HEAD
            var response = await _httpClient.PutAsJsonAsync($"api/v1/dias/{id}", dia);
=======
            var response = await _httpClient.PutAsJsonAsync($"v1/dias/{id}", dia);
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteDiaAsync(int id)
        {
<<<<<<< HEAD
            var response = await _httpClient.DeleteAsync($"api/v1/dias/{id}");
=======
            var response = await _httpClient.DeleteAsync($"v1/dias/{id}");
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
            return response.IsSuccessStatusCode;
        }
    }
}