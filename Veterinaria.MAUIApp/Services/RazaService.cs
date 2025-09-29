using System.Net.Http.Json;
using System.Text.Json;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class RazaService
    {
        private readonly HttpClient _http;

        // Si tu backend usa context-path `/api` o tus @RequestMapping empiezan con `/api`
        // deja este prefijo así. Si NO usas `/api`, cambia a "".
        private const string ApiPrefix = " ";
        private const string Resource = "raza";
        private static readonly string BaseUrl = $"{ApiPrefix}{Resource}";

        private static readonly JsonSerializerOptions JsonOpts = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public RazaService(HttpClient http) => _http = http;

        public async Task<List<RazaSalidaRes>> ObtenerTodosAsync()
        {
            try
            {
                // /api/raza/lista
                var data = await _http.GetFromJsonAsync<List<RazaSalidaRes>>($"{BaseUrl}/lista", JsonOpts);
                return data ?? new();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"[Raza.ObtenerTodosAsync] HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Raza.ObtenerTodosAsync] Genérico: {ex.Message}");
            }
            return new();
        }

        public async Task<RazaSalidaRes?> ObtenerPorIdAsync(byte id)
        {
            try
            {
                return await _http.GetFromJsonAsync<RazaSalidaRes>($"{BaseUrl}/{id}", JsonOpts);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Raza.ObtenerPorIdAsync] {ex.Message}");
                return null;
            }
        }

        public async Task<RazaSalidaRes?> CrearAsync(RazaGuardarReq nuevaRaza)
        {
            try
            {
                var resp = await _http.PostAsJsonAsync(BaseUrl, nuevaRaza);
                if (!resp.IsSuccessStatusCode)
                {
                    var body = await resp.Content.ReadAsStringAsync();
                    Console.WriteLine($"[Raza.CrearAsync] {(int)resp.StatusCode} -> {body}");
                    return null;
                }
                return await resp.Content.ReadFromJsonAsync<RazaSalidaRes>(JsonOpts);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Raza.CrearAsync] {ex.Message}");
                return null;
            }
        }

        public async Task<RazaSalidaRes?> EditarAsync(byte id, RazaModificarReq raza)
        {
            try
            {
                var resp = await _http.PutAsJsonAsync($"{BaseUrl}/{id}", raza);
                if (!resp.IsSuccessStatusCode)
                {
                    var body = await resp.Content.ReadAsStringAsync();
                    Console.WriteLine($"[Raza.EditarAsync] {(int)resp.StatusCode} -> {body}");
                    return null;
                }
                return await resp.Content.ReadFromJsonAsync<RazaSalidaRes>(JsonOpts);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Raza.EditarAsync] {ex.Message}");
                return null;
            }
        }

        public async Task<bool> EliminarAsync(byte id)
        {
            try
            {
                var resp = await _http.DeleteAsync($"{BaseUrl}/{id}");
                if (!resp.IsSuccessStatusCode)
                {
                    var body = await resp.Content.ReadAsStringAsync();
                    Console.WriteLine($"[Raza.EliminarAsync] {(int)resp.StatusCode} -> {body}");
                }
                return resp.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Raza.EliminarAsync] {ex.Message}");
                return false;
            }
        }
    }
}