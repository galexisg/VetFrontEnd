using System.Text;
using System.Text.Json;
using System.Net.Http;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class BloqueHorarioService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:8080/api/v1/bloquehorario"; // Reemplaza con la URL correcta de tu API

        public BloqueHorarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BloqueHorario>> GetBloquesHorarioAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_baseUrl);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var bloques = JsonSerializer.Deserialize<List<BloqueHorario>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return bloques;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los bloques de horario: {ex.Message}");
                return new List<BloqueHorario>();
            }

        }
        public async Task<BloqueHorario> CreateBloqueHorarioAsync(BloqueHorarioRequest nuevoBloque)
        {
            try
            {
                var json = JsonSerializer.Serialize(nuevoBloque);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(_baseUrl, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var createdBloque = JsonSerializer.Deserialize<BloqueHorario>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return createdBloque;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear un nuevo bloque de horario: {ex.Message}");
                return null;
            }
        }
    }

}
