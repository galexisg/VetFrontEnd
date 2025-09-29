using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class TratamientoService
    {
        private readonly HttpClient _http;
        private const string endpoint = "tratamientos";

        public TratamientoService(HttpClient http)
        {
            _http = http;
        }

        // Listar todos
        public async Task<List<Tratamiento>> ObtenerTodosAsync()
        {
            return await _http.GetFromJsonAsync<List<Tratamiento>>(endpoint)
                   ?? new List<Tratamiento>();
        }

        // Obtener por ID
        public async Task<Tratamiento?> ObtenerPorIdAsync(long id)
        {
            return await _http.GetFromJsonAsync<Tratamiento>($"{endpoint}/{id}");
        }

        // Crear nuevo
        public async Task<Tratamiento?> CrearAsync(Tratamiento nuevo)
        {
            var response = await _http.PostAsJsonAsync(endpoint, nuevo);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Tratamiento>();
            return null;
        }

        // Editar existente
        public async Task<bool> EditarAsync(long id, Tratamiento actualizado)
        {
            var response = await _http.PutAsJsonAsync($"{endpoint}/{id}", actualizado);
            return response.IsSuccessStatusCode;
        }

        // Cambiar estado (activar/desactivar)
        // Cambiar estado (activar/desactivar)
        public async Task<bool> CambiarEstadoAsync(long id, bool activo)
        {
            // Aquí ya no agregamos "api/", solo endpoint
            var url = $"{endpoint}/{id}/activar?activo={(activo ? "true" : "false")}";
            using var req = new HttpRequestMessage(HttpMethod.Patch, url);
            var res = await _http.SendAsync(req);
            return res.IsSuccessStatusCode;
        }


        // Método auxiliar para manejar errores de la API
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

    // Clase para manejar respuestas de error de la API
    public class ErrorResponse
    {
        public string? Message { get; set; }
    }
}