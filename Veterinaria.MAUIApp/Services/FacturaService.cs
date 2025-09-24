using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    internal class FacturaService
    {
        private readonly HttpClient _httpClient;

        public FacturaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://10.0.2.2:8080/api/"); // Android Emulator
        }

        public async Task<FacturaDTO?> CrearFactura(FacturaRequestDTO request)
        {
            var response = await _httpClient.PostAsJsonAsync("facturas", request);
            return await response.Content.ReadFromJsonAsync<FacturaDTO>();
        }

        public async Task<FacturaDTO?> ObtenerFactura(long id)
        {
            return await _httpClient.GetFromJsonAsync<FacturaDTO>($"facturas/{id}");
        }

        public async Task<List<FacturaDTO>?> ObtenerFacturasPorCliente(long clienteId)
        {
            return await _httpClient.GetFromJsonAsync<List<FacturaDTO>>($"facturas/cliente/{clienteId}");
        }

        public async Task<List<FacturaDTO>?> ObtenerFacturasPendientes()
        {
            return await _httpClient.GetFromJsonAsync<List<FacturaDTO>>("facturas/pendientes");
        }
    }
}

