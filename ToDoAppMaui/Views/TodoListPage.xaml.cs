using ToDoAppMaui.Models;
using ToDoAppMaui.Services;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace ToDoAppMaui.Views;

public partial class ToDoListPage : ContentPage
{
    private readonly User _user;
    private readonly ApiService _api = new();

    public ToDoListPage(User user)
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

    private async void OnAddTodoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddToDoPage(_user));
    }
}