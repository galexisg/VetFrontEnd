using System.Net.Http.Json;
using Veterinaria.MAUIApplication.Models;

namespace Veterinaria.MAUIApplication.Services
{
    public class MedicamentoService
    {
        private readonly HttpClient _http;
        private const string API_URL = "medicamentos";

        public MedicamentoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Medicamento>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<Medicamento>>($"medicamentos/lista") ?? new();
        }

        public async Task<Medicamento?> GetById(int id)
        {
            return await _http.GetFromJsonAsync<Medicamento>($"medicamentos/{id}");
        }

        public async Task<bool> Create(Medicamento med)
        {
            var res = await _http.PostAsJsonAsync("medicamentos", med);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int id, Medicamento med)
        {
            var res = await _http.PutAsJsonAsync($"medicamentos/{id}", med);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            var res = await _http.DeleteAsync($"medicamentos/{id}");
            return res.IsSuccessStatusCode;
        }
    }
}

