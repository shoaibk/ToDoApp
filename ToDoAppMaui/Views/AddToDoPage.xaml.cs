using ToDoAppMaui.Models;
using ToDoAppMaui.Services;

namespace ToDoAppMaui.Views;

public partial class AddToDoPage
{
    private readonly User _user;
    private readonly ApiService _api = new();

    public AddToDoPage(User user)
    {
        InitializeComponent();
        _user = user;
    }

    private async void OnAddTodoClicked(object sender, EventArgs e)
    {
        string? content = TodoEntry?.Text.Trim();

        // Null-check user fields even though models are non-nullable
        if (string.IsNullOrWhiteSpace(_user.Username) || string.IsNullOrWhiteSpace(_user.Password))
        {
            await DisplayAlert("Login Failed", "Username or password missing.", "OK");
            return;
        }

        // Null-check todo content
        if (string.IsNullOrWhiteSpace(content))
        {
            ErrLabel.Text = "Please enter text...";
            ErrLabel.IsVisible = true;
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
            ErrLabel.Text = "Todo service failed, please try again.";
            ErrLabel.IsVisible = true;
        }
    }
}