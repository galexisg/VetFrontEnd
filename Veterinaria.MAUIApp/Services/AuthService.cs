using System.Net.Http.Json;
using System.Text;
using System.Text.RegularExpressions;
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<LoginRes?> LoginAsync(LoginReq loginReq)
        {
            if (loginReq is null) return null;

            loginReq.NickName = Clean(loginReq.NickName);
            loginReq.Clave = Clean(loginReq.Clave);

            var res = await _http.PostAsJsonAsync("auth/login", loginReq);
            var raw = await res.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine($"[AUTH] {res.StatusCode} -> {raw}");

            if (!res.IsSuccessStatusCode) return null;
            return await res.Content.ReadFromJsonAsync<LoginRes>();
        }

        private static string Clean(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;
            s = s.Trim();
            s = s.Normalize(NormalizationForm.FormKC);
            s = Regex.Replace(s, @"\s+", " ");
            return s;
        }
    }
}
