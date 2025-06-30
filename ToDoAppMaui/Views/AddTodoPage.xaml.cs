using ToDoAppMaui.Models;
using ToDoAppMaui.Services;

namespace ToDoAppMaui.Views;

public partial class AddTodoPage : ContentPage
{
    private User _user;
    private ApiService _api = new();

    public AddTodoPage(User user)
    {
        InitializeComponent();
        _user = user;
    }

    private async void OnAddTodoClicked(object? sender, EventArgs e)
    {
        var title = titleEntry.Text?.Trim();
        if (string.IsNullOrEmpty(title))
        {
            await DisplayAlert("Error", "Todo title cannot be empty", "OK");
            return;
        }

        var todo = new Todo
        {
            Title = title,
            IsCompleted = false
        };

        try
        {
            var success = await _api.AddTodo(_user, todo);

            if (success)
            {
                await DisplayAlert("Success", "Todo added successfully", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Failed to add todo", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }

    private async void OnCancelClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}