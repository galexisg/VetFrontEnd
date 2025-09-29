using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class EspecieService
    {
        private readonly HttpClient _http;
        private const string BaseUrl = "especies";

        public EspecieService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<EspecieRes>> ListarAsync()
        {
            var lista = await _http.GetFromJsonAsync<List<EspecieRes>>(BaseUrl);
            return lista ?? new List<EspecieRes>();
        }

        public async Task<EspecieRes?> ObtenerPorIdAsync(byte id)
        {
            return await _http.GetFromJsonAsync<EspecieRes>($"{BaseUrl}/{id}");
        }

        public async Task<EspecieRes?> CrearAsync(EspecieGuardarReq nueva)
        {
            var response = await _http.PostAsJsonAsync(BaseUrl, nueva);
            return await response.Content.ReadFromJsonAsync<EspecieRes>();
        }

        public async Task<EspecieRes?> ActualizarAsync(EspecieActualizarReq modificada)
        {
            var response = await _http.PutAsJsonAsync(BaseUrl, modificada);
            return await response.Content.ReadFromJsonAsync<EspecieRes>();
        }

        public async Task<bool> EliminarAsync(byte id)
        {
            var response = await _http.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}