using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class DiagnosticoService
    {
        private readonly HttpClient _http;

        public DiagnosticoService(HttpClient http)
        {
            _http = http;
        }

        // Listar diagnósticos por cita
        public async Task<List<Diagnostico>> GetByCitaAsync(long citaId)
        {
            return await _http.GetFromJsonAsync<List<Diagnostico>>(
                       $"citas/{citaId}/diagnosticos")
                   ?? new List<Diagnostico>();
        }

        // Obtener un diagnóstico de la lista por id
        public async Task<Diagnostico?> GetByIdAsync(long citaId, long id)
        {
            var lista = await GetByCitaAsync(citaId);
            return lista.FirstOrDefault(d => d.Id == id);
        }

        public async Task<Diagnostico?> CrearAsync(long citaId, Diagnostico diagnostico)
        {
            var response = await _http.PostAsJsonAsync($"citas/{citaId}/diagnosticos", diagnostico);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Diagnostico>();
            }
            return null;
        }

        // Editar diagnóstico
        public async Task EditarAsync(long citaId, long id, Diagnostico diagnostico)
        {
            await _http.PutAsJsonAsync($"citas/{citaId}/diagnosticos/{id}", diagnostico);
        }

        // Cambiar estado (activar/desactivar)
        public async Task CambiarEstadoAsync(long citaId, long id, bool estado)
        {
            await _http.PatchAsync(
                $"citas/{citaId}/diagnosticos/{id}/estado?activo={estado}",
                null
            );
        }
    }
}