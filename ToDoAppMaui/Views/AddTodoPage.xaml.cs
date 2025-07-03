using ToDoAppMaui.Models;
using ToDoAppMaui.Services;

namespace ToDoAppMaui.Views;

public partial class AddTodoPage : ContentPage
{
    private readonly User      _user;
    private readonly ApiService _api;

    public AddTodoPage(User user, ApiService api)
    {
        InitializeComponent();
        _user = user;
        _api  = api;
    }

    private async void OnAddClicked(object? sender, EventArgs e)
    {
        var title = (titleEntry.Text ?? string.Empty).Trim();

        if (string.IsNullOrWhiteSpace(title))
        {
            await DisplayAlert("Validation", "Todo title cannot be empty.", "OK");
            return;
        }
        var todo = new Todo { Title = title, IsCompleted = false };
        var ok   = await _api.AddTodo(_user, todo);

        if (ok)
        {
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Failed to add todo.", "OK");
        }
    }
}
