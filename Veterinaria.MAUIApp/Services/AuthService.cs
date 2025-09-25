using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
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
            var response = await _http.PostAsJsonAsync("api/auth/login", loginReq);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LoginRes>();
            }
            return null;
        }
    }
}
