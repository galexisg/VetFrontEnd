using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Veterinaria.MAUIApp.Models;
using Veterinaria.MAUIApp.Models.Dtos;

namespace Veterinaria.MAUIApp.Services
{
    public class MotivoService
    {
        private const string _endPoint = "api/motivos";
        private readonly HttpClient _http;

        public MotivoService(HttpClient http)
        {
            _http = http;
        }

        // Este método devuelve una lista vacía en caso de error, por lo que no necesita ser nulable
        public async Task<List<Motivo>> ObtenerTodos()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<Motivo>>(_endPoint) ?? new List<Motivo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener todos los motivos: {ex.Message}");
                return new List<Motivo>();
            }
        }

        public async Task<Motivo?> ObtenerPorId(short id)
        {
            try
            {
                return await _http.GetFromJsonAsync<Motivo>($"{_endPoint}/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener motivo por ID: {ex.Message}");
                return null;
            }
        }

        public async Task<Motivo?> Guardar(MotivoRequest motivoRequest)
        {
            try
            {
                var response = await _http.PostAsJsonAsync(_endPoint, motivoRequest);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Motivo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar motivo: {ex.Message}");
                return null;
            }
        }

        public async Task<Motivo?> Editar(short id, MotivoRequest motivoRequest)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"{_endPoint}/{id}", motivoRequest);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Motivo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar motivo: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> Vincular(MotivoServicioRequest request)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"{_endPoint}/vincular", request);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al vincular motivo: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Desvincular(MotivoServicioRequest request)
        {
            try
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Delete, $"{_endPoint}/desvincular")
                {
                    Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json")
                };
                var response = await _http.SendAsync(httpRequest);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al desvincular motivo: {ex.Message}");
                return false;
            }
        }
    }
}