using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.Views;

public partial class AddTodoPage : ContentPage
{
    private readonly User _user;
    private readonly ApiService _api = new();

    public AddTodoPage(User user)
    {
        InitializeComponent();
        _user = user;
    }

    private async void OnAddTodoClicked(object sender, EventArgs e)
    {
        string content = todoEntry.Text?.Trim();

        if (string.IsNullOrEmpty(content))
        {
            errorLabel.Text = "Todo cannot be empty.";
            errorLabel.IsVisible = true;
            return;
        }

        var newTodo = new Todo
        {
            Title = content,
            IsCompleted = false
        };

        var success = await _api.AddTodo(_user, newTodo);
        if (success)
        {
            await Navigation.PopAsync();
        }
        else
        {
            errorLabel.Text = "Failed to add todo. Try again.";
            errorLabel.IsVisible = true;
        }
    }
}