using System.Net.Http;
using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class DispensaService
    {
        private readonly HttpClient _http;
        private const string Endpoint = "api/dispensas";

        public DispensaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Dispensa_Salida>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Dispensa_Salida>>($"{Endpoint}/lista")
                   ?? new List<Dispensa_Salida>();
        }

        public async Task<Dispensa_Salida?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Dispensa_Salida>($"{Endpoint}/{id}");
        }

        public async Task<List<Dispensa_Salida>> GetByPrescripcionAsync(int prescripcionDetalleId)
        {
            return await _http.GetFromJsonAsync<List<Dispensa_Salida>>($"{Endpoint}/prescripcion/{prescripcionDetalleId}")
                   ?? new List<Dispensa_Salida>();
        }

        public async Task<List<Dispensa_Salida>> GetByAlmacenAsync(int almacenId)
        {
            return await _http.GetFromJsonAsync<List<Dispensa_Salida>>($"{Endpoint}/almacen/{almacenId}")
                   ?? new List<Dispensa_Salida>();
        }

        public async Task<List<Dispensa_Salida>> GetByFechaAsync(DateTime fecha)
        {
            string fechaStr = fecha.ToString("yyyy-MM-dd");
            return await _http.GetFromJsonAsync<List<Dispensa_Salida>>($"{Endpoint}/fecha/{fechaStr}")
                   ?? new List<Dispensa_Salida>();
        }

        public async Task<Dispensa_Salida?> CreateAsync(Dispensa_Guardar dto)
        {
            var response = await _http.PostAsJsonAsync(Endpoint, dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<Dispensa_Salida>()
                : null;
        }

        public async Task<Dispensa_Salida?> UpdateAsync(int id, Dispensa_Actualizar dto)
        {
            var response = await _http.PutAsJsonAsync($"{Endpoint}/{id}", dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<Dispensa_Salida>()
                : null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"{Endpoint}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
