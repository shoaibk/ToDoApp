using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using ToDoAppMaui.Models;
using ToDoAppMaui.Services;

namespace ToDoAppMaui.Views;

public partial class TodoListPage : ContentPage
{
    private readonly User _user;
    private readonly ApiService _api = new();
    public TodoListPage(User user)
    {
        InitializeComponent();
        _user = user;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadTodos();
    }

    private async Task LoadTodos()
    {
        var todos = await _api.GetTodos(_user);
        TodoList.ItemsSource = todos;
    }

    private async void OnAddClicked(object? sender, EventArgs eventArgs)
    {
        await Navigation.PushAsync(new AddTodoPage(_user));
    }
}