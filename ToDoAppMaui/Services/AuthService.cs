using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace ToDoAppMaui.Services;

public class AuthService
{
    private readonly HttpClient _httpClient;
    private const string BaseURL = "http://localhost:5097/api/auth";

    public AuthService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> RegisterAsync(string username, string password)
    {
        try
        {
            var registerUser = new { username, password };

            var json = JsonSerializer.Serialize(registerUser);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{BaseURL}/register", content);

            var responseContent = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode
                ? $"Registration succeeded: {responseContent}"
                : $"Registration failed ({(int)response.StatusCode}): {responseContent}";
        }
        catch (Exception ex)
        {
            return $"Registration error: {ex.Message}";
        }
    }

    public async Task<string> LoginAsync(string username, string password)
    {
        try
        {
            var loginUser = new { username, password };

            var json = JsonSerializer.Serialize(loginUser);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{BaseURL}/login", content);

            var responseContent = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode
                ? $"Login succeeded: {responseContent}"
                : $"Login failed ({(int)response.StatusCode}): {responseContent}";
        }
        catch (Exception ex)
        {
            return $"Login error: {ex.Message}";
        }
    }
}