using System.Net.Http.Json;
using Veterinaria.MAUIApplication.Models;

namespace Veterinaria.MAUIApplication.Services
{
    public class ProveedorService
    {
        private readonly HttpClient _http;
        private const string API_URL = "proveedores";

        public ProveedorService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Proveedor>> ObtenerTodos()
        {
            return await _http.GetFromJsonAsync<List<Proveedor>>($"proveedores/lista");
        }

        public async Task<Proveedor> ObtenerPorId(int id)
        {
            return await _http.GetFromJsonAsync<Proveedor>($"proveedores/{id}");
        }

        public async Task<Proveedor> Crear(Proveedor proveedor)
        {
            var response = await _http.PostAsJsonAsync("proveedores", proveedor);
            return await response.Content.ReadFromJsonAsync<Proveedor>();
        }

        public async Task<Proveedor> Editar(Proveedor proveedor)
        {
            var response = await _http.PutAsJsonAsync($"proveedores/{proveedor.Id}", proveedor);
            return await response.Content.ReadFromJsonAsync<Proveedor>();
        }

        public async Task Eliminar(int id)
        {
            await _http.DeleteAsync($"proveedores/{id}");
        }
    }
}
