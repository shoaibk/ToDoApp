using System.Net.Http.Json;
using ToDoAppMaui.Models;

namespace ToDoAppMaui.Services;

public class ApiService
{
    private readonly HttpClient _httpClient = new();
    private const string BaseUrl = "http://localhost:5097"; //  http://10.0.2.2:5097 for Android

 
    public async Task<bool> RegisterAsync(User user)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/api/auth/register", user);
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
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/api/auth/login", user);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    
    public async Task<List<Todo>> GetTodosAsync(User user)
    {
        try
        {
            var url = $"{BaseUrl}/api/todo?username={user.Username}&password={user.Password}";
            return await _httpClient.GetFromJsonAsync<List<Todo>>(url) ?? new List<Todo>();
        }
        catch
        {
            return new List<Todo>();
        }
    }

    public async Task<bool> AddTodoAsync(User user, Todo todo)
    {
        try
        {
            var url = $"{BaseUrl}/api/todo?username={user.Username}&password={user.Password}";
            var response = await _httpClient.PostAsJsonAsync(url, todo);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}