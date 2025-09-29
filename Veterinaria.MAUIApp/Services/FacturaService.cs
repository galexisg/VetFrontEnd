using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Veterinaria.MAUIApp.Models;
using Veterinaria.MAUIApp.Utils;
using System.Linq;

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

            // 1) intenta lista
            try
            {
                var list = JsonSerializer.Deserialize<List<T>>(body, _json);
                if (list != null) return list;
            }
            catch { /* sigue intentando como single */ }

            // 2) intenta single
            try
            {
                var one = JsonSerializer.Deserialize<T>(body, _json);
                if (one != null) return new List<T> { one };
            }
            catch { /* ignora */ }

            return new List<T>();
        }

        private static List<FacturaDTO> UnirSinDuplicadosOrdenados(params IEnumerable<FacturaDTO>?[] fuentes)
        {
            return fuentes.Where(f => f != null)
                          .SelectMany(f => f!)
                          .DistinctBy(f => f.Id)
                          .OrderByDescending(f => f.Id) // ajusta si tienes createdAt
                          .ToList();
        }

        // ---------- CRUD / consultas básicas ----------
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

        // ---------- Filtros compuestos / UX ----------
        /// <summary>
        /// Carga inicial de la pantalla: PENDIENTE por defecto.
        /// </summary>
        public Task<List<FacturaDTO>> ObtenerInicial(CancellationToken ct = default)
            => ObtenerFacturasPorEstado("PENDIENTE", ct);

        /// <summary>
        /// "No pagadas": PENDIENTE + PARCIAL (+ opcional ANULADA) unidas en cliente.
        /// </summary>
        public async Task<List<FacturaDTO>> ObtenerNoPagadas(bool incluirAnuladas = false, CancellationToken ct = default)
        {
            var pendientes = await ObtenerFacturasPorEstado("PENDIENTE", ct);
            var parciales = await ObtenerFacturasPorEstado("PARCIAL", ct);
            List<FacturaDTO>? anuladas = null;

            if (incluirAnuladas)
                anuladas = await ObtenerFacturasPorEstado("ANULADA", ct);

            return UnirSinDuplicadosOrdenados(pendientes, parciales, anuladas);
        }

        /// <summary>
        /// Intenta llamar a /facturas/estados?in=... (si existe en tu backend).
        /// Si el endpoint no está (404/405), hace fallback uniendo cliente-side.
        /// </summary>
        public async Task<List<FacturaDTO>> ObtenerPorEstados(CancellationToken ct = default, params string[] estados)
        {
            estados = (estados?.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray() ?? Array.Empty<string>());
            if (estados.Length == 0) return new List<FacturaDTO>();

            // 1) Intento endpoint multi-estado (si lo agregas)
            var query = string.Join(",", estados);
            var tryUrl = $"facturas/estados?in={query}";
            var resp = await _http.GetAsync(tryUrl, ct);

            if (resp.IsSuccessStatusCode)
                return await ReadListOrSingle<FacturaDTO>(resp, ct);

            // 2) Fallback: unir en cliente
            var llamadas = estados.Select(e => ObtenerFacturasPorEstado(e, ct));
            var resultados = await Task.WhenAll(llamadas);
            return UnirSinDuplicadosOrdenados(resultados);
        }

        // === CLIENTES (usuarios con rol_id = 2) =========================

        // backend con endpoint dedicado /usuarios/clientes
        public async Task<List<UsuarioMiniDTO>> ObtenerClientes(CancellationToken ct = default)
        {
            // usa tu endpoint actual de backend
            var resp = await _http.GetAsync("usuarios/listarclientes", ct);
            return await ReadListOrSingle<UsuarioMiniDTO>(resp, ct);
        }

        //(fallback): backend con query /usuarios?rolId=2
        public async Task<List<UsuarioMiniDTO>> ObtenerClientesPorRol(CancellationToken ct = default)
        {
            var resp = await _http.GetAsync("usuarios?rolId=2", ct);
            return await ReadListOrSingle<UsuarioMiniDTO>(resp, ct);
        }

        public async Task<List<ServicioMiniDTO>> ObtenerServiciosActivos(CancellationToken ct = default)
        {
            // Tu endpoint lista paginado: mapeamos solo lo necesario
            // Nota: si tu backend devuelve un Page<ServicioRes>, aquí leeremos la propiedad "content".
            var resp = await _http.GetAsync("servicios?activo=true&page=0&size=1000", ct);
            var body = await resp.Content.ReadAsStringAsync(ct);
            if (!resp.IsSuccessStatusCode)
                throw new HttpRequestException($"HTTP {(int)resp.StatusCode} {resp.ReasonPhrase}. Body: {body}");

            // Estructura de Page<> esperada (solo lo que usamos)
            var page = JsonSerializer.Deserialize<PageServicioRes>(body, _json) ?? new PageServicioRes();

            return page.Content.Select(s => new ServicioMiniDTO
            {
                Id = s.Id,
                Nombre = s.Nombre,
                PrecioBase = s.PrecioBase
            }).ToList();
        }

    // Tipos internos para deserializar el Page<ServicioRes>
    class PageServicioRes
        {
            public List<ServicioRes>? Content { get; set; } = new();
        }
        class ServicioRes
        {
            public long Id { get; set; }
            public string? Nombre { get; set; }
            public decimal? PrecioBase { get; set; }
        }
    }

}

