using ToDoAppMaui.Models;
using ToDoAppMaui.Services;

namespace ToDoAppMaui.Views;

public partial class TodoListPage : ContentPage
{
    private readonly User _user;
    private readonly ApiService _api = new();

    public TodoListPage(User user)
    {
        InitializeComponent();
        _user = user;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadTodos();
    }

    private async Task LoadTodos()
    {
        var todos = await _api.GetTodos(_user);
        todoList.ItemsSource = todos;
    }

    private async void OnAddTodoClicked(object sender, EventArgs e)
    {
        var title = todoEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(title))
        {
            await DisplayAlert("Error", "Todo title cannot be empty", "OK");
            return;
        }

        var todo = new Todo { Title = title, IsCompleted = false };

        var success = await _api.AddTodo(_user, todo);

        if (success)
        {
            todoEntry.Text = string.Empty; 
            await LoadTodos(); 
        }
        else
        {
            await DisplayAlert("Error", "Failed to add todo", "OK");
        }
    }
}