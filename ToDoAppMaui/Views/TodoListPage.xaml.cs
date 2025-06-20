using Microsoft.Maui.Controls;
using ToDoAppMaui.Models;
using ToDoAppMaui.Services;


namespace ToDoAppMaui.Views;

public partial class TodoListPage : ContentPage
{
    private readonly User _user;
    private readonly ApiService _apiService = new();

    public TodoListPage(User user)
    {
        InitializeComponent();
        _user = user;
        _ = LoadTodos(); 
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadTodos();
    }

    private async Task LoadTodos()
    {
        try
        {
            var todos = await _apiService.GetTodosAsync(_user);
            TodoList.ItemsSource = todos; 
        }
        catch
        {
            await DisplayAlert("Error", "Failed to load todos. Please try again.", "OK");
        }
    }

    private async void OnAddTodoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTodoPage(_user));
    }
}