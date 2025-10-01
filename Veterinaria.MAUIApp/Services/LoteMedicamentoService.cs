using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http.Json;
using Veterinaria.MAUIApp.Models.Dtos;

namespace Veterinaria.MAUIApp.Services
{
    public class LoteMedicamentoService
    {
        private readonly HttpClient _http;

        public LoteMedicamentoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<LoteMedicamentoSalida>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<LoteMedicamentoSalida>>("api/Lotes_medicamentos/lista")
                   ?? new List<LoteMedicamentoSalida>();
        }

        public async Task<LoteMedicamentoSalida?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<LoteMedicamentoSalida>($"api/Lotes_medicamentos/{id}");
        }

        public async Task<LoteMedicamentoSalida?> AddAsync(LoteMedicamentoGuardar dto)
        {
            var response = await _http.PostAsJsonAsync("api/Lotes_medicamentos", dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<LoteMedicamentoSalida>()
                : null;
        }

        public async Task<LoteMedicamentoSalida?> UpdateAsync(int id, LoteMedicamentoActualizar dto)
        {
            var response = await _http.PutAsJsonAsync($"api/Lotes_medicamentos/{id}", dto);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<LoteMedicamentoSalida>()
                : null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Lotes_medicamentos/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var error = response.Headers.Contains("Error-Message")
                    ? response.Headers.GetValues("Error-Message").FirstOrDefault()
                    : await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error al eliminar lote {id}: {error}");
            }
            return response.IsSuccessStatusCode;
        }



        public async Task<List<LoteMedicamentoSalida>> GetByMedicamentoIdAsync(int medicamentoId)
        {
            return await _http.GetFromJsonAsync<List<LoteMedicamentoSalida>>($"api/Lotes_medicamentos/Medicamento/{medicamentoId}")
                   ?? new List<LoteMedicamentoSalida>();
        }

        public async Task<List<LoteMedicamentoSalida>> GetByProveedorIdAsync(int proveedorId)
        {
            return await _http.GetFromJsonAsync<List<LoteMedicamentoSalida>>($"api/Lotes_medicamentos/proveedor/{proveedorId}")
                   ?? new List<LoteMedicamentoSalida>();
        }

        public async Task<List<LoteMedicamentoSalida>> GetProximosAVencerAsync()
        {
            return await _http.GetFromJsonAsync<List<LoteMedicamentoSalida>>($"api/Lotes_medicamentos/proximos-a-vencer")
                   ?? new List<LoteMedicamentoSalida>();
        }
    }
}

