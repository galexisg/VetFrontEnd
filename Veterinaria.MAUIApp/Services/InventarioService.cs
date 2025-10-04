using System.Net.Http.Json;
using System.Text.Json;
using Veterinaria.MAUIApp.Models;
using Veterinaria.MAUIApp.Models.Dtos;

namespace Veterinaria.MAUIApp.Services
{
    // El backend tiene /api/inventario (paginado) y /api/inventario/lista (lista completa)
    // Usaremos /api/inventario/lista para obtener todos los registros.
    public class InventarioService
    {
        private const string ApiSegmentBase = "/api/inventario"; // Base de la ruta API
        private const string ApiSegmentList = "/api/inventario/lista"; // Ruta para la lista sin paginar
        private readonly HttpClient _httpClient;

        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public InventarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // ----------------------------------------------------------------------
        // 1. OBTENER TODOS LOS REGISTROS (GET /api/inventario/lista)
        // Se apunta al endpoint que devuelve List<> en lugar de Page<>.
        // ----------------------------------------------------------------------
        public async Task<List<Inventario>> GetInventariosAsync()
        {
            try
            {
                // *** CAMBIO CLAVE: Usamos la ruta /api/inventario/lista ***
                HttpResponseMessage response = await _httpClient.GetAsync(ApiSegmentList);

                // --- Verificación explícita del código de estado ---
                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();

                    Console.WriteLine($"[InventarioService] ERROR HTTP {response.StatusCode}: El servidor devolvió un error.");
                    Console.WriteLine($"[API RAW RESPONSE] {errorContent.Substring(0, Math.Min(errorContent.Length, 200))}...");

                    throw new Exception($"ERROR AL CARGAR: La API devolvió el código de estado HTTP {(int)response.StatusCode}. Revise la consola para el contenido del error del servidor.");
                }
                // --------------------------------------------------------

                string content = await response.Content.ReadAsStringAsync();

                // Si es 204 No Content, devolvemos una lista vacía
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent || string.IsNullOrWhiteSpace(content))
                {
                    return new List<Inventario>();
                }

                // Deserializamos manualmente (System.Text.Json)
                List<Inventario>? inventarios = JsonSerializer.Deserialize<List<Inventario>>(content, _jsonOptions);

                return inventarios ?? new List<Inventario>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"[InventarioService] ERROR DE JSON: {ex.Message}. Verifique que la API devuelve una matriz JSON (Ej: [...]).");
                throw new Exception($"Fallo en la carga de inventarios. Causa: El formato JSON recibido no es una lista válida. {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fatal al obtener inventarios: {ex.Message}");
                throw;
            }
        }

        // ----------------------------------------------------------------------
        // 2. OBTENER UN REGISTRO POR ID (GET /api/inventario/{id})
        // ----------------------------------------------------------------------
        public async Task<Inventario?> GetInventarioByIdAsync(int id)
        {
            try
            {
                var url = $"{ApiSegmentBase}/{id}"; // -> /api/inventario/{id}
                return await _httpClient.GetFromJsonAsync<Inventario>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener inventario con ID {id}: {ex.Message}");
                throw;
            }
        }

        // ----------------------------------------------------------------------
        // 3. CREAR UN REGISTRO (POST /api/inventario)
        // ----------------------------------------------------------------------
        public async Task<Inventario?> PostInventarioAsync(InventarioCreacionDto dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ApiSegmentBase, dto);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Inventario>();
                }

                string errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error al crear inventario (HTTP {(int)response.StatusCode}): {errorContent}");

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear inventario (Excepción de red/código): {ex.Message}");
                throw;
            }
        }

        // ----------------------------------------------------------------------
        // 4. ACTUALIZAR UN REGISTRO (PUT /api/inventario/{id})
        // ----------------------------------------------------------------------
        public async Task<bool> PutInventarioAsync(InventarioActualizacionDto dto)
        {
            try
            {
                var url = $"{ApiSegmentBase}/{dto.Id}"; // -> /api/inventario/{id}
                var response = await _httpClient.PutAsJsonAsync(url, dto);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Fallo en la actualización (HTTP {(int)response.StatusCode}): {errorContent}");
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar inventario con ID {dto.Id}: {ex.Message}");
                return false;
            }
        }

        // ----------------------------------------------------------------------
        // 5. ELIMINAR UN REGISTRO (DELETE /api/inventario/{id})
        // ----------------------------------------------------------------------
        public async Task<bool> DeleteInventarioAsync(int id)
        {
            try
            {
                var url = $"{ApiSegmentBase}/{id}"; // -> /api/inventario/{id}
                var response = await _httpClient.DeleteAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Fallo en la eliminación (HTTP {(int)response.StatusCode}): {errorContent}");
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar inventario con ID {id}: {ex.Message}");
                return false;
            }
        }
    }
}