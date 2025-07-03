using System.Net.Http.Json;
using ToDoAppMaui.Models;

namespace ToDoAppMaui.Services;

public class ApiService
{
    private static readonly HttpClient _httpClient = new();

    public async Task<List<Todo>> GetTodos(User user)
    {
        var url = $"http://localhost:5097/api/todo?username={user.Username}&password={user.Password}";
        return await _httpClient.GetFromJsonAsync<List<Todo>>(url);
    }

    public async Task<bool> AddTodo(User user, Todo todo)
    {
        var url = $"http://localhost:5097/api/todo?username={user.Username}&password={user.Password}";
        var response = await _httpClient.PostAsJsonAsync(url, todo);
        return response.IsSuccessStatusCode;
    }
}
