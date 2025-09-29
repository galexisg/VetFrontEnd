using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class TratamientosAplicadosService
    {
        private readonly HttpClient _http;

        public TratamientosAplicadosService(HttpClient http)
        {
            _http = http;
        }

        // GET /api/tratamientos-aplicados?citaId=1
        public async Task<List<TratamientoAplicado>> ListarPorCitaAsync(long citaId)
            => await _http.GetFromJsonAsync<List<TratamientoAplicado>>($"/api/tratamientos-aplicados?citaId={citaId}")
               ?? new List<TratamientoAplicado>();

        // POST /api/tratamientos-aplicados
        public async Task<TratamientoAplicado?> CrearAsync(TratamientoAplicado nuevo)
        {
            var res = await _http.PostAsJsonAsync("/api/tratamientos-aplicados", new
            {
                citaId = nuevo.CitaId,
                tratamientoId = nuevo.TratamientoId,
                veterinarioId = nuevo.VeterinarioId,
                observaciones = nuevo.Observaciones
            });
            return res.IsSuccessStatusCode ? await res.Content.ReadFromJsonAsync<TratamientoAplicado>() : null;
        }

        // PUT /api/tratamientos-aplicados/{id}  (estado)
        public async Task<TratamientoAplicado?> ActualizarEstadoAsync(long id, string estado)
        {
            var res = await _http.PutAsJsonAsync($"/api/tratamientos-aplicados/{id}", new { estado });
            return res.IsSuccessStatusCode ? await res.Content.ReadFromJsonAsync<TratamientoAplicado>() : null;
        }

        // PUT /api/tratamientos-aplicados/{id}  (observaciones)
        public async Task<TratamientoAplicado?> ActualizarObservacionesAsync(long id, string? observaciones)
        {
            var res = await _http.PutAsJsonAsync($"/api/tratamientos-aplicados/{id}", new { observaciones });
            return res.IsSuccessStatusCode ? await res.Content.ReadFromJsonAsync<TratamientoAplicado>() : null;
        }
    }
}
