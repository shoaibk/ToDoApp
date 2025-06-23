using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppMaui.Models;
using ToDoAppMaui.Services;

using ToDoAppMaui.Models;
using ToDoAppMaui.Services;

namespace ToDoAppMaui.Views;

public partial class AddTodoPage : ContentPage
{
    private User _user;
    private ApiService _api = new();

    public AddTodoPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        

        _user = CurrentUser;
    }

    public static User CurrentUser { get; set; }

    private async void OnAddClicked(object sender, EventArgs e)
    {

        string todoTitle = todoEntry.Text?.Trim();
        
        if (string.IsNullOrEmpty(todoTitle))
        {
            await DisplayAlert("Error", "Todo title cannot be empty!", "OK");
            return;
        }

        // Create new todo object
        var newTodo = new Todo
        {
            Title = todoTitle,
            IsCompleted = false
        };
        
        var result = await _api.AddTodo(_user, newTodo);

        if (result != null)
        {
            await Shell.Current.GoToAsync("..");
        }
        else
        {
            await DisplayAlert("Error", "Failed to add todo. Please try again.", "OK");
        }
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        // Go back to todo list without adding
        await Shell.Current.GoToAsync("..");
    }
}