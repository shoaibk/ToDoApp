using System.Text;
using System.Text.Json;
using ToDoAppMaui.Models;

namespace ToDoAppMaui.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "http://localhost:5097"; 

    public ApiService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<bool> RegisterAsync(User user)
    {
        try
        {
            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{BaseUrl}/api/auth/register", content);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> LoginAsync(User user)
    {
        try
        {
            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{BaseUrl}/api/auth/login", content);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}