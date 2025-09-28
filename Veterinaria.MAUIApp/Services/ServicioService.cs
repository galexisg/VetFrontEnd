    using System.Net.Http.Json;
    using System.Text.Json;
    using Veterinaria.MAUIApp.Models;

    namespace Veterinaria.MAUIApp.Services
    {
        public class ServicioService
        {
            private readonly HttpClient _http;
            public ServicioService(HttpClient http) => _http = http;

            /// <summary>
            /// Lista servicios. Devuelve SOLO el 'content' del Page de Spring.
            /// </summary>
            public async Task<List<Servicio>> ListarAsync(string? q = null, bool? activo = null, int page = 0, int size = 20)
            {
                var url = $"api/servicios?page={page}&size={size}";
                if (!string.IsNullOrWhiteSpace(q)) url += $"&q={Uri.EscapeDataString(q)}";
                if (activo.HasValue) url += $"&activo={(activo.Value ? "true" : "false")}";

                try
                {
                    using var stream = await _http.GetStreamAsync(url);
                    using var doc = await JsonDocument.ParseAsync(stream);

                    if (!doc.RootElement.TryGetProperty("content", out var content))
                        return new List<Servicio>();

                    var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    return JsonSerializer.Deserialize<List<Servicio>>(content.GetRawText(), opts) ?? new List<Servicio>();
                }
                catch (Exception ex)
                {
                    // Puedes loguear aquí si quieres
                    throw new InvalidOperationException($"Error al listar servicios: {ex.Message}", ex);
                }
            }

            public Task<Servicio?> ObtenerAsync(long id)
                => _http.GetFromJsonAsync<Servicio>($"api/servicios/{id}");

            public Task<HttpResponseMessage> CrearAsync(Servicio s)
                => _http.PostAsJsonAsync("api/servicios", new
                {
                    nombre = s.Nombre,
                    descripcion = s.Descripcion,
                    precioBase = s.PrecioBase,
                    estado = s.Estado.ToString() // "ACTIVO"/"INACTIVO"
                });

            public Task<HttpResponseMessage> ActualizarAsync(long id, Servicio s)
                => _http.PutAsJsonAsync($"api/servicios/{id}", new
                {
                    nombre = s.Nombre,
                    descripcion = s.Descripcion,
                    precioBase = s.PrecioBase,
                    estado = s.Estado.ToString()
                });

            public Task<HttpResponseMessage> CambiarEstadoAsync(long id, EstadoServicio estado)
                => _http.PatchAsJsonAsync($"api/servicios/{id}", new { estado = estado.ToString() });

            public Task<List<Motivo>?> ListarMotivosPorServicioAsync(long servicioId)
                => _http.GetFromJsonAsync<List<Motivo>>($"api/servicios/{servicioId}/motivos");
        }
    }
