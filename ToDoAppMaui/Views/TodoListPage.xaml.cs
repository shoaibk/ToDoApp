using Microsoft.Maui.Controls;
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
        _ = LoadTodos(); // Fire and forget, but avoids compiler warning
    }

    private async Task LoadTodos()
    {
        try
        {
            var todos = await _api.GetTodos(_user);
            todoList.ItemsSource = todos;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Failed to load todos.", "OK");
            Console.WriteLine(ex);
        }
    }

    private async void OnAddTodoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTodoPage(_user, LoadTodos));
    }
}