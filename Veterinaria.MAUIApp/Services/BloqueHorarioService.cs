<<<<<<< HEAD
﻿using System.Text;
using System.Text.Json;
using System.Net.Http;
using Veterinaria.MAUIApp.Models;
=======
﻿using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;
using static Veterinaria.MAUIApp.Models.BloqueHorario;
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981

namespace Veterinaria.MAUIApp.Services
{
    public class BloqueHorarioService
    {
<<<<<<< HEAD
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

=======
        private readonly HttpClient _http;

        public BloqueHorarioService(HttpClient http)
        {
            _http = http;
        }

        // Listar activos
        public async Task<List<BloqueHorarioSalidaRes>> ListarActivosAsync()
        {
            return await _http.GetFromJsonAsync<List<BloqueHorarioSalidaRes>>("bloques-horario/activos")
                   ?? new List<BloqueHorarioSalidaRes>();
        }

        // Listar inactivos
        public async Task<List<BloqueHorarioSalidaRes>> ListarInactivosAsync()
        {
            return await _http.GetFromJsonAsync<List<BloqueHorarioSalidaRes>>("bloques-horario/inactivos")
                   ?? new List<BloqueHorarioSalidaRes>();
        }

        // 🔹 Listar TODOS (activos + inactivos) para validaciones
        public async Task<List<BloqueHorarioSalidaRes>> ListarTodosAsync()
        {
            return await _http.GetFromJsonAsync<List<BloqueHorarioSalidaRes>>("bloques-horario")
                   ?? new List<BloqueHorarioSalidaRes>();
        }

        // Buscar por Id
        public async Task<BloqueHorarioSalidaRes?> BuscarPorIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<BloqueHorarioSalidaRes>($"bloques-horario/{id}");
        }

        // Crear
        public async Task<BloqueHorarioSalidaRes?> CrearAsync(BloqueHorarioGuardarReq dto)
        {
            var response = await _http.PostAsJsonAsync("bloques-horario/crear", dto);
            return await response.Content.ReadFromJsonAsync<BloqueHorarioSalidaRes>();
        }

        // Modificar
        public async Task<BloqueHorarioSalidaRes?> ModificarAsync(int id, BloqueHorarioModificarReq dto)
        {
            var response = await _http.PutAsJsonAsync($"bloques-horario/{id}/editar", dto);
            return await response.Content.ReadFromJsonAsync<BloqueHorarioSalidaRes>();
        }

        // Activar
        public async Task<bool> ActivarAsync(int id)
        {
            var response = await _http.PutAsync($"bloques-horario/{id}/activar", null);
            return response.IsSuccessStatusCode;
        }

        // Desactivar
        public async Task<bool> DesactivarAsync(int id)
        {
            var response = await _http.DeleteAsync($"bloques-horario/{id}/desactivar");
            return response.IsSuccessStatusCode;
        }


    }
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
}
