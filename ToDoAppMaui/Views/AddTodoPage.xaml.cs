using System;
using Microsoft.Maui.Controls;
using ToDoAppMaui.Models;
using ToDoAppMaui.Services;

namespace ToDoAppMaui.Views;

public partial class AddTodoPage : ContentPage
{
    private readonly User _user;
    private readonly ApiService _apiService = new();

    public AddTodoPage(User user)
    {
        InitializeComponent();
        _user = user;
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        var title = TodoEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(title))
        {
            await DisplayAlert("Error", "Todo title can't be empty.", "OK");
            return;
        }

        var todo = new Todo
        {
            Title = title,
            IsCompleted = IsCompleteCheckbox.IsChecked
        };

        var success = await _apiService.AddTodo(_user, todo);

        if (success)
        {
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Failed to add the todo to the list.", "OK");
        }
    }
}