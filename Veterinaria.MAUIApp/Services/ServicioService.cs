using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;
using Veterinaria.MAUIApp.Models.Dtos;

namespace Veterinaria.MAUIApp.Services
{
    public class ServicioService
    {
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
    }
}