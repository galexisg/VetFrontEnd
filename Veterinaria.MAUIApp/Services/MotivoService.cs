using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class MotivoService
    {
        private readonly HttpClient _http;
        public MotivoService(HttpClient http) => _http = http;

        public Task<List<Motivo>?> ListarAsync()
            => _http.GetFromJsonAsync<List<Motivo>>("api/motivos");

        public Task<Motivo?> ObtenerAsync(short id)
            => _http.GetFromJsonAsync<Motivo>($"api/motivos/{id}");

        // Tu backend ahora solo recibe { nombre } en POST/PUT
        public Task<HttpResponseMessage> CrearAsync(Motivo m)
            => _http.PostAsJsonAsync("api/motivos", new { nombre = m.Nombre });

        public Task<HttpResponseMessage> ActualizarAsync(short id, Motivo m)
            => _http.PutAsJsonAsync($"api/motivos/{id}", new { nombre = m.Nombre });

        public Task<HttpResponseMessage> VincularAsync(short motivoId, long servicioId)
            => _http.PostAsJsonAsync("api/motivos/vincular", new { motivoId, servicioId });

        public Task<HttpResponseMessage> DesvincularAsync(short motivoId, long servicioId)
            => _http.SendAsync(new HttpRequestMessage(HttpMethod.Delete, "api/motivos/desvincular")
            {
                Content = JsonContent.Create(new { motivoId, servicioId })
            });

        public Task<HttpResponseMessage> EliminarAsync(short id)
            => _http.DeleteAsync($"api/motivos/{id}");
    }
}