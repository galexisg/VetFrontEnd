using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;
using static Veterinaria.MAUIApp.Models.BloqueHorario;

namespace Veterinaria.MAUIApp.Services
{
    public class BloqueHorarioService
    {
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
}
