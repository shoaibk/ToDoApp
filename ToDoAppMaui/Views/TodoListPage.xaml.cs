using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        todoList.ItemsSource = todos;
    }
    private async void OnAddClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTodoPage(_user, _api));
    }
}
