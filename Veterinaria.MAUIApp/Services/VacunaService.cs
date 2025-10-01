using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class VacunaService
    {
        private const string _endpoint = "vacunas";
        private readonly HttpClient _http;

        public VacunaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Vacuna>> ListarAsync(string? q = null)
        {
            var url = string.IsNullOrWhiteSpace(q) ? _endpoint : $"{_endpoint}?q={Uri.EscapeDataString(q)}";
            var data = await _http.GetFromJsonAsync<List<Vacuna>>(url);
            return data ?? new List<Vacuna>();
        }

        public Task<Vacuna?> ObtenerAsync(int id)
            => _http.GetFromJsonAsync<Vacuna>($"{_endpoint}/{id}");

        public async Task<Vacuna?> CrearAsync(VacunaReq req)
        {
            var resp = await _http.PostAsJsonAsync(_endpoint, req);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<Vacuna>();
        }

        public async Task<Vacuna?> ActualizarAsync(int id, VacunaReq req)
        {
            var resp = await _http.PutAsJsonAsync($"{_endpoint}/{id}", req);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<Vacuna>();
        }

        public async Task<bool> HabilitarAsync(int id)
            => (await _http.PatchAsync($"{_endpoint}/habilitar/{id}", content: null)).IsSuccessStatusCode;

        public async Task<bool> DeshabilitarAsync(int id)
            => (await _http.PatchAsync($"{_endpoint}/deshabilitar/{id}", content: null)).IsSuccessStatusCode;

        public async Task<bool> ToggleEstadoAsync(Vacuna v)
            => v.Estado ? await DeshabilitarAsync(v.Id) : await HabilitarAsync(v.Id);
    }
}
