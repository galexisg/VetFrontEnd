using System.Net.Http.Json;
<<<<<<< HEAD
=======
using System.Text.Json;
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class RazaService
    {
        private readonly HttpClient _http;
<<<<<<< HEAD
        private const string BaseUrl = "api/raza";

        public RazaService(HttpClient http)
        {
            _http = http;
        }
=======

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
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981

        public async Task<List<RazaSalidaRes>> ObtenerTodosAsync()
        {
            try
            {
<<<<<<< HEAD
                var response = await _http.GetFromJsonAsync<List<RazaSalidaRes>>($"{BaseUrl}/lista");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ObtenerTodosAsync] Error: {ex.Message}");
                return new(); // Evita que Blazor falle
            }
=======
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
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
        }

        public async Task<RazaSalidaRes?> ObtenerPorIdAsync(byte id)
        {
            try
            {
<<<<<<< HEAD
                return await _http.GetFromJsonAsync<RazaSalidaRes>($"{BaseUrl}/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ObtenerPorIdAsync] Error: {ex.Message}");
=======
                return await _http.GetFromJsonAsync<RazaSalidaRes>($"{BaseUrl}/{id}", JsonOpts);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Raza.ObtenerPorIdAsync] {ex.Message}");
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
                return null;
            }
        }

        public async Task<RazaSalidaRes?> CrearAsync(RazaGuardarReq nuevaRaza)
        {
            try
            {
<<<<<<< HEAD
                var response = await _http.PostAsJsonAsync(BaseUrl, nuevaRaza);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<RazaSalidaRes>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CrearAsync] Error: {ex.Message}");
=======
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
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
                return null;
            }
        }

        public async Task<RazaSalidaRes?> EditarAsync(byte id, RazaModificarReq raza)
        {
            try
            {
<<<<<<< HEAD
                var response = await _http.PutAsJsonAsync($"{BaseUrl}/{id}", raza);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<RazaSalidaRes>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EditarAsync] Error: {ex.Message}");
=======
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
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
                return null;
            }
        }

        public async Task<bool> EliminarAsync(byte id)
        {
            try
            {
<<<<<<< HEAD
                var response = await _http.DeleteAsync($"{BaseUrl}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EliminarAsync] Error: {ex.Message}");
=======
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
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
                return false;
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981
