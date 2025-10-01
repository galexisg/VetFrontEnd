using System.Net.Http.Json;
<<<<<<< HEAD
using Veterinaria.MAUIApp.Models;
using Veterinaria.MAUIApp.Models.Dtos;
using static Veterinaria.MAUIApp.Models.Servicio;
=======
using System.Text.Json;
using Veterinaria.MAUIApp.Models;
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981

namespace Veterinaria.MAUIApp.Services
{
    public class ServicioService
    {
<<<<<<< HEAD
        private const string _endPoint = "api/servicios";
        private readonly HttpClient _http;

        public ServicioService(HttpClient http)
        {
            _http = http;
        }

        // Se añade '?' para indicar que el resultado puede ser nulo en caso de error
        public async Task<PagedResult<Servicio>?> ObtenerPaginado(string q = null, bool? activo = null, int page = 0, int size = 10)
        {
            try
            {
                var queryParams = new List<string> { $"page={page}", $"size={size}" };
                if (!string.IsNullOrWhiteSpace(q)) queryParams.Add($"q={q}");
                if (activo.HasValue) queryParams.Add($"activo={activo.Value.ToString().ToLower()}");

                var requestUri = $"{_endPoint}?{string.Join("&", queryParams)}";
                return await _http.GetFromJsonAsync<PagedResult<Servicio>>(requestUri);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener servicios paginados: {ex.Message}");
                return null;
            }
        }

        public async Task<Servicio?> ObtenerPorId(long id)
        {
            try
            {
                return await _http.GetFromJsonAsync<Servicio>($"{_endPoint}/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener servicio por ID: {ex.Message}");
                return null;
            }
        }

        public async Task<Servicio?> Guardar(ServicioRequest servicioRequest)
        {
            try
            {
                var response = await _http.PostAsJsonAsync(_endPoint, servicioRequest);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Servicio>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar servicio: {ex.Message}");
                return null;
            }
        }

        public async Task<Servicio?> Editar(long id, ServicioRequest servicioRequest)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"{_endPoint}/{id}", servicioRequest);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Servicio>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar servicio: {ex.Message}");
                return null;
            }
        }

        public async Task<Servicio?> CambiarEstado(long id, ServicioEstadoRequest estadoRequest)
        {
            try
            {
                var response = await _http.PatchAsJsonAsync($"{_endPoint}/{id}", estadoRequest);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Servicio>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cambiar estado de servicio: {ex.Message}");
                return null;
            }
        }

        public async Task<List<ServicioRes>> ObtenerActivosAsync()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<PagedResult<ServicioRes>>("api/servicios?activo=true&page=0&size=100");
                return result?.Content ?? new List<ServicioRes>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener servicios activos: {ex.Message}");
                return new List<ServicioRes>();
            }
        }


=======
        private readonly HttpClient _http;
        public ServicioService(HttpClient http) => _http = http;

        /// <summary>
        /// Lista servicios. Devuelve SOLO el 'content' del Page de Spring.
        /// </summary>
        public async Task<List<Servicio>> ListarAsync(string? q = null, bool? activo = null, int page = 0, int size = 20)
        {
            var url = $"servicios?page={page}&size={size}";
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
            => _http.GetFromJsonAsync<Servicio>($"servicios/{id}");

        public Task<HttpResponseMessage> CrearAsync(Servicio s)
            => _http.PostAsJsonAsync("servicios", new
            {
                nombre = s.Nombre,
                descripcion = s.Descripcion,
                precioBase = s.PrecioBase,
                estado = s.Estado.ToString() // "ACTIVO"/"INACTIVO"
            });

        public Task<HttpResponseMessage> ActualizarAsync(long id, Servicio s)
            => _http.PutAsJsonAsync($"servicios/{id}", new
            {
                nombre = s.Nombre,
                descripcion = s.Descripcion,
                precioBase = s.PrecioBase,
                estado = s.Estado.ToString()
            });

        public Task<HttpResponseMessage> CambiarEstadoAsync(long id, EstadoServicio estado)
            => _http.PatchAsJsonAsync($"servicios/{id}", new { estado = estado.ToString() });

        public Task<List<Motivo>?> ListarMotivosPorServicioAsync(long servicioId)
            => _http.GetFromJsonAsync<List<Motivo>>($"servicios/{servicioId}/motivos");
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
    }
}