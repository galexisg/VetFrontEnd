using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Veterinaria.MAUIApp.Models;
using Veterinaria.MAUIApp.Models.Dtos;

namespace Veterinaria.MAUIApp.Services
{
    // Clase concreta, sin implementar una interfaz
    public class MovimientoInventarioService
    {
        // La ruta específica para este recurso en la API de Java
        private const string ApiRoute = "api/movimientosInventario";
        private readonly HttpClient _httpClient;

        // Opciones de serialización para manejar el formato JSON (camelCase de Java)
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        // HttpClient se inyecta en MauiProgram.cs
        public MovimientoInventarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // ----------------------------------------------------------------------
        // 1. OBTENER TODOS LOS REGISTROS (GET /api/movimientosInventario)
        // ----------------------------------------------------------------------
        public async Task<List<MovimientoInventario>> GetMovimientosInventarioAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(ApiRoute);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var movimientos = JsonSerializer.Deserialize<List<MovimientoInventario>>(content, _jsonOptions);

                return movimientos ?? new List<MovimientoInventario>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MovimientoInventarioService] Error al obtener movimientos: {ex.Message}");
                return new List<MovimientoInventario>();
            }
        }

        // ----------------------------------------------------------------------
        // 2. OBTENER UN REGISTRO POR ID (GET /api/movimientosInventario/{id})
        // ----------------------------------------------------------------------
        public async Task<MovimientoInventario?> GetMovimientoInventarioByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiRoute}/{id}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<MovimientoInventario>(content, _jsonOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MovimientoInventarioService] Error al obtener movimiento con ID {id}: {ex.Message}");
                return null;
            }
        }

        // ----------------------------------------------------------------------
        // 3. CREAR UN REGISTRO (POST /api/movimientosInventario) - MÉTODO CORREGIDO
        // Ahora usa el nombre del método esperado por la página Blazor y devuelve el objeto creado.
        // ----------------------------------------------------------------------
        public async Task<MovimientoInventario?> CrearMovimientoAsync(MovimientoInventarioCreacionDto dto)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(dto, _jsonOptions);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(ApiRoute, content);

                if (response.IsSuccessStatusCode)
                {
                    // La API debería devolver el objeto MovimientoInventario completo (con su ID)
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<MovimientoInventario>(responseContent, _jsonOptions);
                }

                // Si no fue exitoso, lanza una excepción para ser capturada
                response.EnsureSuccessStatusCode();
                return null; // No debería llegar aquí
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MovimientoInventarioService] Error al crear movimiento: {ex.Message}");
                return null;
            }
        }

        // ----------------------------------------------------------------------
        // ** (MÉTODO ANTERIOR - RENOMBRADO, MANTENIDO POR SI LO NECESITAS) **
        // ----------------------------------------------------------------------
        // public async Task<bool> PostMovimientoInventarioAsync(MovimientoInventarioCreacionDto dto)
        // {
        //     // Implementación original para POST que devuelve bool
        //     // ...
        //     return true;
        // }


        // ----------------------------------------------------------------------
        // 4. ACTUALIZAR UN REGISTRO (PUT /api/movimientosInventario/{id})
        // ----------------------------------------------------------------------
        public async Task<bool> PutMovimientoInventarioAsync(MovimientoInventarioActualizacionDto dto)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(dto, _jsonOptions);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{ApiRoute}/{dto.Id}", content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MovimientoInventarioService] Error al actualizar ID {dto.Id}: {ex.Message}");
                return false;
            }
        }

        // ----------------------------------------------------------------------
        // 5. ELIMINAR UN REGISTRO (DELETE /api/movimientosInventario/{id})
        // ----------------------------------------------------------------------
        public async Task<bool> DeleteMovimientoInventarioAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiRoute}/{id}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MovimientoInventarioService] Error al eliminar ID {id}: {ex.Message}");
                return false;
            }
        }
    }
}