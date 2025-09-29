using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class ServicioTratamientoService
    {
        private readonly HttpClient _http;
        private const string endpoint = "api/servicio-tratamientos";

        public ServicioTratamientoService(HttpClient http)
        {
            _http = http;
        }

        // Listar por servicio
        public async Task<List<ServicioTratamiento>> ObtenerPorServicioAsync(long servicioId)
        {
            return await _http.GetFromJsonAsync<List<ServicioTratamiento>>($"{endpoint}?servicioId={servicioId}")
                   ?? new List<ServicioTratamiento>();
        }

        // Crear nuevo
        public async Task<ServicioTratamiento?> CrearAsync(ServicioTratamiento nuevo)
        {
            var response = await _http.PostAsJsonAsync(endpoint, nuevo);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<ServicioTratamiento>();
            return null;
        }

        // Eliminar
        public async Task<bool> EliminarAsync(long id)
        {
            var response = await _http.DeleteAsync($"{endpoint}/{id}");
            return response.IsSuccessStatusCode;
        }

        // Cambiar estado (activar/inactivar)
        public async Task<bool> CambiarEstadoAsync(long id, bool activo)
        {
            var accion = activo ? "activar" : "inactivar";
            var response = await _http.PatchAsync($"{endpoint}/{id}/{accion}", null);
            return response.IsSuccessStatusCode;
        }

        // Manejo de errores
        public async Task<string?> GetErrorMessageAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                    return errorResponse?.Message;
                }
                catch
                {
                    return $"Error {response.StatusCode}: {response.ReasonPhrase}";
                }
            }
            return null;
        }
    }
}
