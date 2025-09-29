using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class CompraService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:8080/api/v1/compras"; // 👈 Ajusta la URL a tu endpoint real

        public CompraService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtener todas las compras
        public async Task<List<Compra>> GetComprasAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_baseUrl);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var compras = JsonSerializer.Deserialize<List<Compra>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return compras ?? new List<Compra>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener compras: {ex.Message}");
                return new List<Compra>();
            }
        }

        // Obtener una compra por ID
        public async Task<Compra?> GetCompraByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Compra>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener compra con ID {id}: {ex.Message}");
                return null;
            }
        }

        // Crear una nueva compra
        public async Task<Compra?> CreateCompraAsync(Compra nuevaCompra)
        {
            try
            {
                var json = JsonSerializer.Serialize(nuevaCompra);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(_baseUrl, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Compra>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear compra: {ex.Message}");
                return null;
            }
        }

        // Actualizar una compra existente
        public async Task<Compra?> UpdateCompraAsync(int id, Compra compraActualizada)
        {
            try
            {
                var json = JsonSerializer.Serialize(compraActualizada);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{_baseUrl}/{id}", content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Compra>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar compra con ID {id}: {ex.Message}");
                return null;
            }
        }

        // Eliminar una compra
        public async Task<bool> DeleteCompraAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar compra con ID {id}: {ex.Message}");
                return false;
            }
        }
    }
}
