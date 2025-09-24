using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    internal class PagoService
    {
        private readonly HttpClient _httpClient;

        public PagoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://10.0.2.2:8080/api/");
        }

        public async Task<PagoDTO?> RegistrarPago(PagoRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("pagos", request);
            return await response.Content.ReadFromJsonAsync<PagoDTO>();
        }

        public async Task<PagoDTO?> ObtenerPago(long id)
        {
            return await _httpClient.GetFromJsonAsync<PagoDTO>($"pagos/{id}");
        }

        public async Task<List<PagoDTO>?> ObtenerPagosPorFactura(long facturaId)
        {
            return await _httpClient.GetFromJsonAsync<List<PagoDTO>>($"pagos/factura/{facturaId}");
        }

        public async Task<TotalResponse?> ObtenerTotalPagado(long facturaId)
        {
            return await _httpClient.GetFromJsonAsync<TotalResponse>($"pagos/factura/{facturaId}/total");
        }
    }
}

