using ToDoAppMaui.Models;
using ToDoAppMaui.Services;
using Microsoft.Maui.Controls;
using System;

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

    private async void OnAddTodoClicked(object sender, EventArgs e)
    {
        string content = TodoEntry.Text;

        if (string.IsNullOrWhiteSpace(_user.Username) || string.IsNullOrWhiteSpace(_user.Password))
        {
            await DisplayAlert("Login Failed", "Username or password missing.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(content))
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