using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Veterinaria.MAUIApp.Models; // Ajusta el namespace si es diferente
using Veterinaria.MAUIApp.Models.Dtos; // Ajusta el namespace si es diferente

namespace Veterinaria.MAUIApp.Services
{
    public class MovimientoDetalleService
    {
        // La ruta relativa que coincide con el @RequestMapping del controlador de Java
        private const string ApiSegment = "/api/movimientoDetalle";
        private readonly HttpClient _http;

        // El HttpClient se inyecta desde MauiProgram.cs
        public MovimientoDetalleService(HttpClient http)
        {
            _http = http;
        }

        // ----------------------------------------------------------------------
        // 1. OBTENER TODOS LOS REGISTROS (GET /api/movimientoDetalle/lista)
        // ----------------------------------------------------------------------
        public async Task<List<MovimientoDetalle>> GetTodosAsync()
        {
            try
            {
                // El endpoint de Java es /lista para obtener todos sin paginar
                var detalles = await _http.GetFromJsonAsync<List<MovimientoDetalle>>($"{ApiSegment}/lista");

                // Devuelve la lista o una nueva lista vacía si la respuesta es null (ej. 204 No Content)
                return detalles ?? new List<MovimientoDetalle>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener Movimientos Detalle: {ex.Message}");
                // Puedes optar por lanzar la excepción o devolver una lista vacía
                throw;
            }
        }

        // ----------------------------------------------------------------------
        // 2. OBTENER POR ID (GET /api/movimientoDetalle/{id})
        // ----------------------------------------------------------------------
        public async Task<MovimientoDetalle?> GetByIdAsync(int id)
        {
            try
            {
                var url = $"{ApiSegment}/{id}";
                // Devuelve el objeto o null si la API retorna 404/204
                return await _http.GetFromJsonAsync<MovimientoDetalle>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener Movimiento Detalle ID {id}: {ex.Message}");
                throw;
            }
        }

        // ----------------------------------------------------------------------
        // 3. OBTENER POR MOVIMIENTO INVENTARIO ID (GET /api/movimientoDetalle/movimientoInventario/{id})
        // ----------------------------------------------------------------------
        public async Task<List<MovimientoDetalle>> GetByMovimientoInventarioIdAsync(int id)
        {
            try
            {
                var url = $"{ApiSegment}/movimientoInventario/{id}";
                var detalles = await _http.GetFromJsonAsync<List<MovimientoDetalle>>(url);
                return detalles ?? new List<MovimientoDetalle>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener Movimiento Detalle por Movimiento Inventario ID {id}: {ex.Message}");
                throw;
            }
        }

        // ----------------------------------------------------------------------
        // 4. CREAR (POST /api/movimientoDetalle)
        // ----------------------------------------------------------------------
        public async Task<MovimientoDetalle?> CrearAsync(MovimientoDetalleCreacionDto dto)
        {
            try
            {
                var response = await _http.PostAsJsonAsync(ApiSegment, dto);

                if (response.IsSuccessStatusCode)
                {
                    // La API de Java devuelve el DTO de salida (MovimientoDetalle_Salida)
                    return await response.Content.ReadFromJsonAsync<MovimientoDetalle>();
                }

                // Opcional: Manejar errores específicos del cuerpo de la respuesta aquí.
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear Movimiento Detalle: {ex.Message}");
                throw;
            }
        }

        // ----------------------------------------------------------------------
        // 5. EDITAR (PUT /api/movimientoDetalle/{id})
        // Nota: La API de Java usa el ID del Path, pero el DTO ya tiene el ID.
        // ----------------------------------------------------------------------
        public async Task<MovimientoDetalle?> EditarAsync(MovimientoDetalleActualizacionDto dto)
        {
            try
            {
                var url = $"{ApiSegment}/{dto.Id}";
                var response = await _http.PutAsJsonAsync(url, dto);

                if (response.IsSuccessStatusCode)
                {
                    // La API de Java devuelve el DTO de salida
                    return await response.Content.ReadFromJsonAsync<MovimientoDetalle>();
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar Movimiento Detalle ID {dto.Id}: {ex.Message}");
                throw;
            }
        }

        // ----------------------------------------------------------------------
        // 6. ELIMINAR (DELETE /api/movimientoDetalle/{id})
        // ----------------------------------------------------------------------
        public async Task<bool> EliminarAsync(int id)
        {
            try
            {
                var url = $"{ApiSegment}/{id}";
                var response = await _http.DeleteAsync(url);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar Movimiento Detalle ID {id}: {ex.Message}");
                return false;
            }
        }
    }
}