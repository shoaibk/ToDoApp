using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToDoAppMaui.Services
{
    public class AuthService
    {
        private readonly HttpClient _client;

        public AuthService()
        {
           
            _client = new HttpClient { BaseAddress = new Uri("http://localhost:5097") };
        }

        public async Task<bool> RegisterAsync(string username, string password)
        {
            var payload = JsonSerializer.Serialize(new { username, password });
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            var res = await _client.PostAsync("api/auth/register", content);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var payload = JsonSerializer.Serialize(new { username, password });
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            var res = await _client.PostAsync("api/auth/login", content);
            return res.IsSuccessStatusCode;
        }
    }
}