<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;
using static Veterinaria.MAUIApp.Models.Servicio;
using static Veterinaria.MAUIApp.Models.VeterinarioGuardarReq;
using ServicioRes = Veterinaria.MAUIApp.Models.VeterinarioGuardarReq.ServicioRes;

=======
﻿using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models;
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981

namespace Veterinaria.MAUIApp.Services
{
    public class VeterinarioService
    {
        private readonly HttpClient _http;

        public VeterinarioService(HttpClient http)
        {
            _http = http;
        }

<<<<<<< HEAD
        // Obtener todos
        public async Task<List<VeterinarioSalidaRes>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<VeterinarioSalidaRes>>("api/veterinarios")
                   ?? new List<VeterinarioSalidaRes>();
        }

        // Obtener activos
        public async Task<List<VeterinarioSalidaRes>> GetActivosAsync()
        {
            return await _http.GetFromJsonAsync<List<VeterinarioSalidaRes>>("api/veterinarios/activos")
                   ?? new List<VeterinarioSalidaRes>();
        }

        // Guardar nuevo
        public async Task<VeterinarioSalidaRes?> AddAsync(VeterinarioGuardarReq nuevo)
        {
            var response = await _http.PostAsJsonAsync("api/veterinarios", nuevo);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<VeterinarioSalidaRes>();
            return null;
        }

        // Modificar
        public async Task<VeterinarioSalidaRes?> UpdateAsync(int id, VeterinarioModificarReq update)
        {
            var response = await _http.PutAsJsonAsync($"api/veterinarios/{id}", update);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<VeterinarioSalidaRes>();
            return null;
        }

        // Activar
        public async Task<bool> ActivarAsync(int id)
        {
            var response = await _http.PutAsync($"api/veterinarios/{id}/activar", null);
            return response.IsSuccessStatusCode;
        }

        // Inactivar
        public async Task<bool> InactivarAsync(int id)
        {
            var response = await _http.PutAsync($"api/veterinarios/{id}/inactivar", null);
            return response.IsSuccessStatusCode;
        }
        // Obtener inactivos
        public async Task<List<VeterinarioSalidaRes>> GetInactivosAsync()
        {
            return await _http.GetFromJsonAsync<List<VeterinarioSalidaRes>>("api/veterinarios/inactivos")
                   ?? new List<VeterinarioSalidaRes>();
        }

        public async Task<List<EspecialidadSalidaRes>> GetEspecialidadesAsync()
        {
            return await _http.GetFromJsonAsync<List<EspecialidadSalidaRes>>("api/especialidades")
                   ?? new List<EspecialidadSalidaRes>();
        }

        public async Task<List<ServicioRes>> GetServiciosAsync()
        {
            return await _http.GetFromJsonAsync<List<ServicioRes>>("api/servicios")
                   ?? new List<ServicioRes>();
        }

    }
}

=======
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
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
