using ToDoAppMaui.Models;
using ToDoAppMaui.Services;

namespace ToDoAppMaui.Views;

public partial class AddTodoPage : ContentPage
{
    private readonly User _user;
    private readonly ApiService _api = new();
    private readonly Func<Task> _refreshCallback;

    public AddTodoPage(User user, Func<Task> refreshCallback)
    {
        InitializeComponent();
        _user = user;
        _refreshCallback = refreshCallback;
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        var todoText = todoEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(todoText))
        {
            await DisplayAlert("Error", "Todo cannot be empty!", "OK");
            return;
        }

        var newTodo = new Todo
        {
            Title = todoText,
            IsCompleted = false
        };

        var success = await _api.AddTodo(_user, newTodo);

        if (success)
        {
            await DisplayAlert("Success", "Todo added!", "OK");
            if (_refreshCallback != null)
                await _refreshCallback(); // Refresh the list
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Something went wrong!", "OK");
        }
    }
}