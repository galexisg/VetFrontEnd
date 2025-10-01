using System.Net.Http.Json;
using VetApp.Models;

namespace VetApp.Services
{
    public class CompraService
    {
        private readonly HttpClient _httpClient;

        public CompraService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private const string BaseUrl = "/api/compras";

        public async Task<List<Compra>> ObtenerTodasAsync()
        {
            var compras = await _httpClient.GetFromJsonAsync<List<Compra>>(BaseUrl);
            return compras ?? new List<Compra>();
        }

        public async Task<Compra> ObtenerPorIdAsync(long id)
        {
            return await _httpClient.GetFromJsonAsync<Compra>($"{BaseUrl}/{id}");
        }

        public async Task<Compra> CrearAsync(CompraCrear compra)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, compra);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Compra>();
        }

        public async Task<Compra> ActualizarAsync(long id, CompraActualizar compra)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", compra);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Compra>();
        }

        public async Task CancelarAsync(long id, CompraCancelar compra)
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, $"{BaseUrl}/{id}")
            {
                Content = JsonContent.Create(compra)
            });
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Compra>> ObtenerPorProveedorAsync(int proveedorId)
        {
            var compras = await _httpClient.GetFromJsonAsync<List<Compra>>($"{BaseUrl}/proveedor/{proveedorId}");
            return compras ?? new List<Compra>();
        }

        public async Task<List<Compra>> ObtenerPorFechaAsync(DateTime fecha)
        {
            var compras = await _httpClient.GetFromJsonAsync<List<Compra>>($"{BaseUrl}/fecha/{fecha:yyyy-MM-dd}");
            return compras ?? new List<Compra>();
        }

        public async Task<List<Compra>> ObtenerPorUsuarioAsync(int usuarioId)
        {
            var compras = await _httpClient.GetFromJsonAsync<List<Compra>>($"{BaseUrl}/usuario/{usuarioId}");
            return compras ?? new List<Compra>();
        }
    }

    public class CompraDetalleService
    {
        private readonly HttpClient _httpClient;

        public CompraDetalleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private const string BaseUrl = "/api/compra-detalle";

        public async Task<List<CompraDetalle>> ListarDetallesAsync()
        {
            var detalles = await _httpClient.GetFromJsonAsync<List<CompraDetalle>>(BaseUrl);
            return detalles ?? new List<CompraDetalle>();
        }

        public async Task<CompraDetalle> ObtenerDetalleAsync(long id)
        {
            return await _httpClient.GetFromJsonAsync<CompraDetalle>($"{BaseUrl}/{id}");
        }

        public async Task<CompraDetalle> CrearDetalleAsync(CrearDetalle detalle)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, detalle);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CompraDetalle>();
        }

        public async Task<CompraDetalle> ActualizarDetalleAsync(long id, ActualizarDetalle detalle)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", detalle);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CompraDetalle>();
        }

        public async Task EliminarDetalleAsync(long id, CancelarDetalle detalle)
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, $"{BaseUrl}/{id}")
            {
                Content = JsonContent.Create(detalle)
            });
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<CompraDetalle>> DetallesPorCompraAsync(long compraId)
        {
            var detalles = await _httpClient.GetFromJsonAsync<List<CompraDetalle>>($"{BaseUrl}/compra/{compraId}");
            return detalles ?? new List<CompraDetalle>();
        }
    }
}
