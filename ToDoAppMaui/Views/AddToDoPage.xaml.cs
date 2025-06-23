using ToDoAppMaui.Models;
using ToDoAppMaui.Services;

namespace ToDoAppMaui.Views;

public partial class AddToDoPage : ContentPage
{
    private readonly User _user;
    private readonly ApiService _api = new();

    public AddToDoPage(User user)
    {
        InitializeComponent();
        _user = user;
    }

    private async void OnAddToDoClicked(object? sender, EventArgs e)
    {
        string todoTitle = TodoEntry.Text?.Trim();
        bool isCompleted = IsCompletedCheckbox.IsChecked;

        if (string.IsNullOrWhiteSpace(todoTitle))
        {
            await DisplayAlert("Error", "Todo title cannot be empty.", "OK");
            return;
        }

        var newTodo = new Todo
        {
            Title = todoTitle,
            IsCompleted = isCompleted
        };

        bool success = await _api.AddTodo(_user, newTodo);
        if (success)
        {
            await DisplayAlert("Success", "Todo added!", "OK");
            await Navigation.PopAsync(); 
        }
        else
        {
            await DisplayAlert("Error", "Failed to add todo.", "OK");
        }
    }
}