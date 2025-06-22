using ToDoAppMaui.Services;
using ToDoAppMaui.Models;
using System;

namespace TodoAppMaui.Views;

public partial class AddToDoPage : ContentPage
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
        string content = TodoEntry.Text;

        if (content == null || content.Trim() == "")
        {
            errLabel.Text = "Please enter text...";
            errLabel.IsVisible = true;
            return;
        }

        var newTodo = new Todo
        {
            Title = content.Trim(),
            IsCompleted = false
        };

        var success = await _api.AddTodo(_user, newTodo);
        if (success)
        {
            await Navigation.PopAsync();
        }
        else
        {
            errLabel.Text = "Todo service failed, please try again.";
            errLabel.IsVisible = true;
        }
    }
}