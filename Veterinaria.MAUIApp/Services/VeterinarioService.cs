using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class VeterinarioService
    {
        private readonly HttpClient _http;

        public VeterinarioService(HttpClient http)
        {
            _http = http;
        }

        // 📌 Listar todos
        public async Task<List<VeterinarioSalidaRes>> ListarAsync()
        {
            return await _http.GetFromJsonAsync<List<VeterinarioSalidaRes>>("veterinarios")
                   ?? new List<VeterinarioSalidaRes>();
        }

        // 📌 Listar activos
        public async Task<List<VeterinarioSalidaRes>> ListarActivos()
        {
            return await _http.GetFromJsonAsync<List<VeterinarioSalidaRes>>("veterinarios/activos")
                   ?? new List<VeterinarioSalidaRes>();
        }

        // 📌 Listar inactivos
        public async Task<List<VeterinarioSalidaRes>> ListarInactivos()
        {
            return await _http.GetFromJsonAsync<List<VeterinarioSalidaRes>>("veterinarios/inactivos")
                   ?? new List<VeterinarioSalidaRes>();
        }

        // 📌 Obtener por ID
        public async Task<VeterinarioSalidaRes?> ObtenerAsync(int id)
        {
            return await _http.GetFromJsonAsync<VeterinarioSalidaRes>($"veterinarios/{id}");
        }

        // 📌 Crear
        public async Task<bool> CrearAsync(VeterinarioGuardarReq modelo)
        {
            var response = await _http.PostAsJsonAsync("veterinarios", modelo);
            return response.IsSuccessStatusCode;
        }

        // 📌 Editar
        public async Task<bool> EditarAsync(int id, VeterinarioModificarReq modelo)
        {
            var response = await _http.PutAsJsonAsync($"veterinarios/{id}", modelo);
            return response.IsSuccessStatusCode;
        }

        // 📌 Activar
        // 📌 Activar usando el nuevo endpoint
        public async Task<bool> ActivarAsync(int id)
        {
            var dto = new VeterinarioEstadoReq { Id = id, Estado = "Activo" };
            var response = await _http.PutAsJsonAsync("veterinarios/estado", dto);
            return response.IsSuccessStatusCode;
        }

        // 📌 Inactivar usando el nuevo endpoint
        public async Task<bool> InactivarAsync(int id)
        {
            var dto = new VeterinarioEstadoReq { Id = id, Estado = "Inactivo" };
            var response = await _http.PutAsJsonAsync("veterinarios/estado", dto);
            return response.IsSuccessStatusCode;
        }



        // 📌 Listar usuarios con rol Veterinario
        public async Task<List<UsuarioSalidaRes>> ListarUsuariosVeterinariosAsync()
        {
            return await _http.GetFromJsonAsync<List<UsuarioSalidaRes>>("veterinarios/usuarios")
                   ?? new List<UsuarioSalidaRes>();
        }
    }
}
