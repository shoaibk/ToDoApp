using System.Net.Http.Json;
using ToDoAppMaui.Models;

namespace ToDoAppMaui.Services;

public class ApiService
{
    private HttpClient _httpClient = new HttpClient();

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
    public async Task<bool> UpdateTodo(User user, Todo todo)
    {
        var url = $"http://localhost:5097/api/todo?username={user.Username}&password={user.Password}";
        Console.WriteLine($"PUT Todo Id: {todo.Id}, Title: {todo.Title}, IsCompleted: {todo.IsCompleted}, UserId: {todo.UserId}");

        var response = await _httpClient.PutAsJsonAsync(url, todo);

        return response.IsSuccessStatusCode;
    }

}