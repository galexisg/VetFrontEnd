// Services/PagoService.cs
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    internal class PagoService
    {
        private readonly HttpClient _httpClient;
        private static readonly JsonSerializerOptions Camel = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        public PagoService(HttpClient httpClient)
        {
            _httpClient = httpClient; // BaseAddress viene de MauiProgram (p.ej. http://10.0.2.2:8080/)
        }

        public async Task<PagoDTO?> RegistrarPago(PagoRequest request)
        {
            // 1) Normaliza la fecha: sin zona, sin milis
            var fechaLocal = request.FechaPago;
            if (fechaLocal.Kind != DateTimeKind.Unspecified)
                fechaLocal = DateTime.SpecifyKind(fechaLocal, DateTimeKind.Unspecified);

            // 2) Construimos el payload *explicitando* el formato que Spring espera
            var payload = new
            {
                facturaId = request.FacturaId,
                metodo = request.Metodo,
                monto = request.Monto,
                fechaPago = fechaLocal.ToString("yyyy-MM-dd'T'HH:mm:ss") // clave del fix
            };

            // OJO: si tu HttpClient.BaseAddress ya es http://10.0.2.2:8080/ (sin /api),
            // aquí usa "api/pagos". Si tu BaseAddress YA tiene /api, usa "pagos".
            var url = "pagos";

            var json = System.Text.Json.JsonSerializer.Serialize(payload,
                new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
                });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Log opcional para ver EXACTAMENTE qué mandas
            System.Diagnostics.Debug.WriteLine($"[POST {url}] {json}");

            var res = await _httpClient.PostAsync(url, content);
            var body = await res.Content.ReadAsStringAsync();

            if (!res.IsSuccessStatusCode)
                throw new HttpRequestException($"POST /{url} -> {(int)res.StatusCode} {res.ReasonPhrase}. Body: {body}");

            return System.Text.Json.JsonSerializer.Deserialize<PagoDTO>(body,
                new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }


        public Task<PagoDTO?> ObtenerPago(long id)
            => _httpClient.GetFromJsonAsync<PagoDTO>($"pagos/{id}", Camel);

        public Task<List<PagoDTO>?> ObtenerPagosPorFactura(long facturaId)
            => _httpClient.GetFromJsonAsync<List<PagoDTO>>($"pagos/factura/{facturaId}", Camel);

        public Task<TotalResponse?> ObtenerTotalPagado(long facturaId)
            => _httpClient.GetFromJsonAsync<TotalResponse>($"pagos/factura/{facturaId}/total", Camel);
    }

    internal class TotalResponse { public decimal Total { get; set; } }
}
