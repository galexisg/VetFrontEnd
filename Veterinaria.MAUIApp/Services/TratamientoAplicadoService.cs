using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class TratamientoAplicadoService
    {
        private readonly HttpClient _http;
        private const string endpoint = "api/tratamientos-aplicados";

        public TratamientoAplicadoService(HttpClient http)
        {
            _http = http;
        }

        // GET /api/tratamientos-aplicados?citaId=123
        public async Task<List<TratamientoAplicado>?> ListarPorCitaAsync(long citaId)
        {
            return await _http.GetFromJsonAsync<List<TratamientoAplicado>>($"{endpoint}?citaId={citaId}");
        }

        // POST /api/tratamientos-aplicados
        public async Task<TratamientoAplicado?> CrearAsync(TratamientoAplicado nuevo)
        {
            var payload = new
            {
                citaId = nuevo.CitaId,
                tratamientoId = nuevo.TratamientoId,
                veterinarioId = nuevo.VeterinarioId,
                observaciones = nuevo.Observaciones
            };

            var response = await _http.PostAsJsonAsync(endpoint, payload);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TratamientoAplicado>();
            }
            return null;
        }

        // PUT /api/tratamientos-aplicados/{id}
        public async Task<bool> EditarAsync(long id, string estado, string? observaciones)
        {
            var payload = new { estado, observaciones };
            var response = await _http.PutAsJsonAsync($"{endpoint}/{id}", payload);
            return response.IsSuccessStatusCode;
        }
    }
}