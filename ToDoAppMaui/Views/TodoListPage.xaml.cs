using ToDoAppMaui.Models;
using ToDoAppMaui.Services;

namespace ToDoAppMaui.Views;

public partial class TodoListPage : ContentPage
{
    private User _user;
    private ApiService _api = new();

    public TodoListPage(User user)
    {
        InitializeComponent();
        _user = user;
        LoadTodos();
    }

    private async Task LoadTodos()
    {
        var todos = await _api.GetTodos(_user);
        todoList.ItemsSource = todos;
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        var newTitle = newTodoEntry.Text?.Trim();

        if (string.IsNullOrEmpty(newTitle))
        {
            await DisplayAlert("Validation Error", "Task cannot be empty.", "OK");
            return;
        }

        var newTodo = new Todo { Title = newTitle, IsCompleted = false };
        var success = await _api.AddTodo(_user, newTodo);

        if (success)
        {
            newTodoEntry.Text = string.Empty; 
            await LoadTodos(); 
        }
        else
        {
            await DisplayAlert("Error", "Failed to add todo.", "OK");
        }
    }
}