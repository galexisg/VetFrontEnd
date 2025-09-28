using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Veterinaria.MAUIApp.Models;
using Veterinaria.MAUIApp.Utils;

namespace Veterinaria.MAUIApp.Services
{
    public class FacturaService
    {
        private readonly HttpClient _http;
        private static readonly JsonSerializerOptions _json = new(JsonSerializerDefaults.Web);

        public FacturaService(HttpClient http, ApiOptions opts)
        {
            _http = http;
            if (_http.BaseAddress is null && !string.IsNullOrWhiteSpace(opts.BaseUrl))
                _http.BaseAddress = new Uri(opts.BaseUrl);
        }

        // ---------- Helpers ----------
        private static async Task<List<T>> ReadListOrSingle<T>(HttpResponseMessage resp, CancellationToken ct)
        {
            var body = await resp.Content.ReadAsStringAsync(ct);

            if (!resp.IsSuccessStatusCode)
                throw new HttpRequestException(
                    $"HTTP {(int)resp.StatusCode} {resp.ReasonPhrase}. Body: {body}");

            // 1) intenta deserializar como lista
            try
            {
                var list = JsonSerializer.Deserialize<List<T>>(body, _json);
                if (list != null) return list;
            }
            catch { /* sigue intentando como single */ }

            // 2) intenta deserializar como un solo objeto
            try
            {
                var one = JsonSerializer.Deserialize<T>(body, _json);
                if (one != null) return new List<T> { one };
            }
            catch { /* si tampoco, devuelve lista vacía */ }

            return new List<T>();
        }

        // ---------- CRUD / consultas ----------
        public async Task<FacturaDTO?> CrearFactura(FacturaRequestDTO dto, CancellationToken ct = default)
        {
            var resp = await _http.PostAsJsonAsync("facturas", dto, _json, ct);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<FacturaDTO>(_json, ct);
        }

        public async Task<FacturaDTO?> ObtenerFactura(long id, CancellationToken ct = default)
        {
            var resp = await _http.GetAsync($"facturas/{id}", ct);
            if (!resp.IsSuccessStatusCode) return null;
            return await resp.Content.ReadFromJsonAsync<FacturaDTO>(_json, ct);
        }

        public async Task<List<FacturaDTO>> ObtenerFacturasPorCliente(long clienteId, CancellationToken ct = default)
        {
            var resp = await _http.GetAsync($"facturas/cliente/{clienteId}", ct);
            return await ReadListOrSingle<FacturaDTO>(resp, ct);
        }

        public async Task<List<FacturaDTO>> ObtenerFacturasPorEstado(string estado, CancellationToken ct = default)
        {
            var resp = await _http.GetAsync($"facturas/estado/{estado}", ct);
            return await ReadListOrSingle<FacturaDTO>(resp, ct);
        }

        public async Task<List<FacturaDTO>> ObtenerFacturasPendientes(CancellationToken ct = default)
        {
            var resp = await _http.GetAsync("facturas/pendientes", ct);
            return await ReadListOrSingle<FacturaDTO>(resp, ct);
        }
    }
}
