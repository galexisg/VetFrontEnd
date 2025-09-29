using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class MotivoService
    {
        private readonly HttpClient _http;
        public MotivoService(HttpClient http) => _http = http;

        // GET /api/motivos
        public Task<List<Motivo>?> ListarAsync()
            => _http.GetFromJsonAsync<List<Motivo>>("motivos");

        // GET /api/motivos/{id}
        public Task<Motivo?> ObtenerAsync(short id)
            => _http.GetFromJsonAsync<Motivo>($"motivos/{id}");

        // POST /api/motivos
        public Task<HttpResponseMessage> CrearAsync(Motivo m)
            => _http.PostAsJsonAsync("motivos", new { nombre = m.Nombre });

        // PUT /api/motivos/{id}
        public Task<HttpResponseMessage> ActualizarAsync(short id, Motivo m)
            => _http.PutAsJsonAsync($"motivos/{id}", new { nombre = m.Nombre });

        // POST /api/motivos/vincular
        public Task<HttpResponseMessage> VincularAsync(short motivoId, long servicioId)
            => _http.PostAsJsonAsync("motivos/vincular", new { motivoId, servicioId });

        // DELETE /api/motivos/desvincular  (con body JSON)
        public Task<HttpResponseMessage> DesvincularAsync(short motivoId, long servicioId)
            => _http.SendAsync(new HttpRequestMessage(HttpMethod.Delete, "motivos/desvincular")
            {
                Content = JsonContent.Create(new { motivoId, servicioId })
            });

        // DELETE /api/motivos/{id}
        public Task<HttpResponseMessage> EliminarAsync(short id)
            => _http.DeleteAsync($"motivos/{id}");
    }
}
