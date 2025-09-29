using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class MotivoCitaService
    {
        private readonly HttpClient _http;

        public MotivoCitaService(HttpClient http)
        {
            _http = http;
        }

        // Listar motivos activos
        public async Task<List<MotivoCita>> GetActivosAsync()
        {
            return await _http.GetFromJsonAsync<List<MotivoCita>>("motivos")
                   ?? new List<MotivoCita>();
        }

        // Obtener un motivo por id (de la lista de activos)
        public async Task<MotivoCita?> GetByIdAsync(int id)
        {
            var lista = await GetActivosAsync();
            return lista.FirstOrDefault(m => m.Id == id);
        }

        // Crear nuevo motivo
        //public async Task<MotivoCita?> CrearAsync(MotivoCita motivo)
        //{
        //    var response = await _http.PostAsJsonAsync("motivos", motivo);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return await response.Content.ReadFromJsonAsync<MotivoCita>();
        //    }
        //    return null;
        //}
        // Crear nuevo motivo
        public async Task<(MotivoCita? motivo, string? error)> CrearAsync(MotivoCita motivo)
        {
            var response = await _http.PostAsJsonAsync("motivos", motivo);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<MotivoCita>();
                return (data, null); // No hay error
            }
            else
            {
                // Intentar leer mensaje de error del backend
                try
                {
                    var errorResp = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                    return (null, errorResp?.Message ?? "Error desconocido");
                }
                catch
                {
                    return (null, $"Error {response.StatusCode}: {response.ReasonPhrase}");
                }
            }
        }


        // Editar motivo existente
        public async Task<bool> EditarAsync(int id, MotivoCita motivo)
        {
            var response = await _http.PutAsJsonAsync($"motivos/{id}", motivo);
            return response.IsSuccessStatusCode;
        }

        // Desactivar motivo
        public async Task<bool> DesactivarAsync(int id)
        {
            var response = await _http.PutAsync($"motivos/{id}/desactivar", null);
            return response.IsSuccessStatusCode;
        }

        // Activar motivo
        public async Task<bool> ActivarAsync(int id)
        {
            var response = await _http.PutAsync($"motivos/{id}/activar", null);
            return response.IsSuccessStatusCode;
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