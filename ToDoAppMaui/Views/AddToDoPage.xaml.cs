using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using ToDoAppMaui.Models;
using ToDoAppMaui.Services;

namespace ToDoAppMaui.Views;

public partial class AddToDoPage : ContentPage
{
    private Todo _todo = new Todo();
    private User _user;
    private ApiService _apiService = new ApiService();
    private Action _loadTodos;

    public AddToDoPage(User user,  Action loadTodos)
    {
        InitializeComponent();
        _user = user;
        _loadTodos = loadTodos;
    }

    private async void OnDoneClicked(object? sender, EventArgs e)
    {
        if (String.IsNullOrWhiteSpace(TitleEntry.Text))
        {
            await DisplayAlert("Error", "Title is empty", "Ok");
            return;
        }
        _todo.Title = TitleEntry.Text.Trim();
        _todo.IsCompleted = IsCompletedSwitch.IsToggled;
        
        await _apiService.AddTodo(_user, _todo);
        _loadTodos.Invoke();
        await Navigation.PopAsync();
    }
}