using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json;

using System.Text;
using System.Text.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services;

public class AgendaService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "http://localhost:8080/api/v1/detallehorarioveterinario";

    public AgendaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Método para obtener todos los detalles de horario
    public async Task<List<DetalleHorarioVeterinario>> GetDetallesHorarioAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var agenda = JsonSerializer.Deserialize<List<DetalleHorarioVeterinario>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return agenda;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener los detalles del horario: {ex.Message}");
            return new List<DetalleHorarioVeterinario>();
        }
    }

    // Método para obtener un detalle de horario por su ID
    public async Task<DetalleHorarioVeterinario> GetDetalleHorarioByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var detalle = JsonSerializer.Deserialize<DetalleHorarioVeterinario>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return detalle;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener el detalle de horario con ID {id}: {ex.Message}");
            return null;
        }
    }

    // Método para crear un nuevo detalle de horario
    public async Task<DetalleHorarioVeterinario> CreateDetalleHorarioAsync(DetalleHorarioVeterinario nuevoDetalle)
    {
        try
        {
            var json = JsonSerializer.Serialize(nuevoDetalle);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_baseUrl, content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var createdDetalle = JsonSerializer.Deserialize<DetalleHorarioVeterinario>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return createdDetalle;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear un nuevo detalle de horario: {ex.Message}");
            return null;
        }
    }

    // Método para actualizar un detalle de horario existente
    public async Task<DetalleHorarioVeterinario> UpdateDetalleHorarioAsync(int id, DetalleHorarioVeterinario detalleActualizado)
    {
        try
        {
            var json = JsonSerializer.Serialize(detalleActualizado);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_baseUrl}/{id}", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var updatedDetalle = JsonSerializer.Deserialize<DetalleHorarioVeterinario>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return updatedDetalle;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar el detalle de horario con ID {id}: {ex.Message}");
            return null;
        }
    }

    // Método para eliminar un detalle de horario
    public async Task<bool> DeleteDetalleHorarioAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            response.EnsureSuccessStatusCode();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar el detalle de horario con ID {id}: {ex.Message}");
            return false;
        }
    }
}